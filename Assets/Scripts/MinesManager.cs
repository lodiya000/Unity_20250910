using UnityEngine;

namespace Lodiya
{
    public class MinesManager : MonoBehaviour
    {
        [SerializeField]
        //炸彈數量
        public int minesCount = 10;
        [SerializeField]
        public GameObject baseBox;

        //沒炸彈為0 炸彈為1 道具
        public int[,] mines = new int[5,5];
        
        public Grid[,] mineGrid = new Grid[5,5];
        private Grid grid;

        public int point = 0;

        [SerializeField]
        public Sprite[] num = new Sprite[9];
        [SerializeField]
        public Sprite bomb;

        private void Awake()
        {
            for(int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    int c = x * 5 + y;
                    mineGrid[x, y] = gameObject.transform.GetChild(c).gameObject.transform.GetComponent<Grid>();
                    mineGrid[x, y].SetPosition(x,y);
                    mines[x, y] = 0;   

                    mineGrid[x, y].item.sprite = null;
                }
            }

            //埋炸彈
            for (int i = 0; i < minesCount; i++)
            {
                int x = Random.Range(0,5);
                int y = Random.Range(0,5);

                mines[x,y] = 1;
                mineGrid[x, y].item.sprite = bomb;
            }

            Debug.Log("reset");
        }

        /// <summary>
        /// 翻開格子
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Click(int x, int y)
        {
            mineGrid[x, y].cover.color = Color.clear;
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
                    mineGrid[x, y].item.sprite = num[count-1];
                    point = point + count;
                }
            }
            else if (mines[x, y] == 1)
            {
                Debug.Log("地雷");
            }
        }

        public void Mark(int x, int y)
        {
            Debug.Log("標記");

            if(mineGrid[x, y].canOpen)
            { 
                mineGrid[x, y].cover.color = Color.red;
            }
            else if (!mineGrid[x, y].canOpen)
            {
                mineGrid[x, y].cover.color = Color.HSVToRGB(50,97,100);
            }

            mineGrid[x, y].canOpen = !mineGrid[x, y].canOpen;
        }


        public bool Search(int x, int y)
        {
            if (x > 4 || x < 0) return false;
            if (y > 4 || y < 0) return false;
            //if (mines[x - 1, y + 1] == null) return false; 
            if (mines[x, y] == 1) return true;
            else return false;
        }
    }
}