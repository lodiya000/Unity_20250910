using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Lodiya
{
    public enum unit
    {
        None, Enemy, Item
    }

    public class MinesManager : MonoBehaviour
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static MinesManager _instance;
        //讓外部取得的窗口 (唯獨)
        public static MinesManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<MinesManager>();

                return _instance;
            }
        }
        #endregion

        //炸彈數量
        [SerializeField]
        public int minesCount = 10;

        //已標記的數量
        private int marking = 0;
        //被標記的地雷
        private int markingMines = 0;

        /// <summary>
        /// 地格大小 n*n的n
        /// </summary>
        [SerializeField]
        private int gridCount = 5;


        /// <summary>
        /// 0 該格為 空格 
        /// 1 該格為 怪物
        /// 2 該格為 道具
        /// </summary>
        public int[,] mines;

        [SerializeField]
        public unit[,] uints;

        public Grid[,] mineGrid;


        //數字圖標
        [SerializeField]
        public Sprite[] num = new Sprite[9];

        [SerializeField]
        private WaveData waveData;

        private void Awake()
        {
            mines = new int[gridCount, gridCount];
            mineGrid = new Grid[gridCount, gridCount];
            uints = new unit[gridCount, gridCount];

            int co = gridCount * gridCount;

            //取得所有的格子
            for (int x = 0; x < gridCount; x++)
            {
                for (int y = 0; y < gridCount; y++)
                {
                    int c = x * gridCount + y;
                    mineGrid[x, y] = gameObject.transform.GetChild(c).gameObject.transform.GetComponent<Grid>();
                    mineGrid[x, y].SetPosition(x, y);
                    mines[x, y] = 0;
                }
            }

            //執行敵人生成
            for (int i = 0;i < waveData.enemy.Length;i++)
            {
                waveData.enemy[i].SpwanMod(gridCount);

            }

            //執行道具生成
            for (int i = 0; i < waveData.items.Length; i++)
            {
                Spawn(i);
            }
        }

        public void Spawn(int i)
        {
            int x = Random.Range(0, gridCount);
            int y = Random.Range(0, gridCount);

            if (mineGrid[x, y].unit == null)
            {
                mines[x, y] = 2;
                uints[x, y] = unit.Item;
                waveData.items[i].SetItem(x, y);
            }
            else
            {
                Debug.Log($"道具重疊 重新設定");
                Spawn(i);
            }
        }

        /// <summary>
        /// 翻開
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Flip(int x, int y)
        {
            //確認該格子能否翻開
            if (!mineGrid[x,y].canOpen || mineGrid[x, y].isFlip) return;

            //if(mineGrid[x, y].isFlip)

            if (mines[x, y] != 0)
            {
                mineGrid[x, y].Flip();
            }
            else if (mines[x, y] == 0)
            {
                mineGrid[x, y].Flip();

                #region 計算周遭
                int count = 0;
                for (int dx = -1; dx <= 1; dx++)
                {
                    for (int dy = -1; dy <= 1; dy++)
                    {
                        if (dx == 0 && dy == 0) continue;

                        if (Search(x + dx, y + dy)) count++;
                    }
                }

                if (count > 0)
                {
                    mineGrid[x, y].itemCanvas.alpha = 1;
                    mineGrid[x, y].gridImg.sprite = num[count - 1];
                }
                #endregion
            }
        }

        private Color c;
        /// <summary>
        /// 標記
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Mark(int x, int y)
        {
            //Debug.Log("標記");
            
            if (mineGrid[x, y].canOpen)
            {
                marking++;
                if (mines[x, y] == 1) markingMines++;

                c = mineGrid[x, y].cover.color;
                mineGrid[x, y].cover.color = Color.red;
            }
            else if (!mineGrid[x, y].canOpen)
            {
                marking--;
                if (mines[x, y] == 1) markingMines--;

                mineGrid[x, y].cover.color = c;
            }            

            //若已標記的數量與炸彈數量相同
            if (markingMines == waveData.enemy.Length)
                Debug.Log($"<color=#5f5>遊戲通關");

            mineGrid[x, y].canOpen = !mineGrid[x, y].canOpen;
        }

        /// <summary>
        /// 探測(單格)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Search(int x, int y)
        {
            if (x > gridCount - 1 || x < 0) return false;
            if (y > gridCount - 1 || y < 0) return false;
            if (uints[x, y] != unit.None) 
            {
                return true;
            }
            else return false;
        }
    }
}