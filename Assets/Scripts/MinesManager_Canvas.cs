using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Lodiya
{
    public class MinesManager_Canvas : MonoBehaviour
    {
        //炸彈數量
        [SerializeField]
        public int minesCount = 10;

        //已標記的數量
        private int marking = 0;
        //被標記的地雷
        private int markingMines = 0;

        [SerializeField]
        private int gridCount = 5;

        [SerializeField]
        public GameObject baseBox;

        //沒炸彈為0 炸彈為1 道具
        public int[,] mines;
 
        public Grid_Canvas[,] mineGrid;

        [SerializeField]
        private GameManager gameManager;

        //數字與炸彈圖標
        [SerializeField]
        public Sprite[] num = new Sprite[9];
        [SerializeField]
        public Sprite bomb;

        private void Awake()
        {
            mines = new int[gridCount, gridCount];
            mineGrid = new Grid_Canvas[gridCount, gridCount];

            int co = gridCount * gridCount;

            for (int x = 0; x < gridCount; x++)
            {
                for (int y = 0; y < gridCount; y++)
                {
                    int c = x * gridCount + y;
                    mineGrid[x, y] = gameObject.transform.GetChild(c).gameObject.transform.GetComponent<Grid_Canvas>();
                    mineGrid[x, y].SetPosition(x, y);
                    mines[x, y] = 0;

                    mineGrid[x, y].item.sprite = null;
                    mineGrid[x, y].item.color = Color.clear;
                }
            }

            //埋炸彈
            for (int i = 0; i < minesCount; i++)
            {
                int x = Random.Range(0, gridCount);
                int y = Random.Range(0, gridCount);

                mines[x, y] = 1;
                mineGrid[x, y].item.color = Color.white;
                mineGrid[x, y].item.sprite = bomb;
            }
        }

        /// <summary>
        /// 翻開
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Click(int x, int y)
        {
            mineGrid[x, y].Open();
            if (mines[x, y] == 0)
            {
                Debug.Log("安全");

                #region 計算周遭
                int count = 0;
                if (Search(x - 1, y + 1)) count++;
                if (Search(x, y + 1)) count++;
                if (Search(x + 1, y + 1)) count++;

                if (Search(x - 1, y)) count++;
                if (Search(x + 1, y)) count++;

                if (Search(x - 1, y - 1)) count++;
                if (Search(x, y - 1)) count++;
                if (Search(x + 1, y - 1)) count++;
                #endregion

                if (count > 0)
                {
                    mineGrid[x, y].item.color = Color.white;
                    mineGrid[x, y].item.sprite = num[count - 1];
                }
            }
            else if (mines[x, y] == 1)
            {
                Debug.Log("地雷");
                gameManager.UpdateHP(-5);
            }
        }

        /// <summary>
        /// 標記
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Mark(int x, int y)
        {
            Debug.Log("標記");

            if (mineGrid[x, y].canOpen)
            {
                marking++;
                if (mines[x, y] == 1) markingMines++;

                mineGrid[x, y].cover.color = Color.red;
            }
            else if (!mineGrid[x, y].canOpen)
            {
                marking--;
                if (mines[x, y] == 1) markingMines--;

                mineGrid[x, y].cover.color = Color.yellow;
            }            

            //若已標記的數量與炸彈數量相同
            if (markingMines == minesCount)
                Debug.Log($"<color=#5f5>遊戲通關");

            mineGrid[x, y].canOpen = !mineGrid[x, y].canOpen;
        }

        /// <summary>
        /// 探測
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool Search(int x, int y)
        {
            if (x > gridCount - 1 || x < 0) return false;
            if (y > gridCount - 1 || y < 0) return false;
            //if (mines[x - 1, y + 1] == null) return false; 
            if (mines[x, y] == 1) return true;
            else return false;
        }
    }
}