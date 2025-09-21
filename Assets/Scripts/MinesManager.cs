using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Lodiya
{
    public class MinesManager : MonoBehaviour
    {
        [SerializeField]
        //炸彈數量
        public int minesCount = 10;
        [SerializeField]
        public GameObject baseBox;
        public int[,] mines = new int[5,5];
        //沒炸彈為0 炸彈為1 道具
        public Grid[,] mineGrid = new Grid[5,5];
        public Grid grid;

        private void Awake()
        {
            for(int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    int c = i * 5 + j;
                    mineGrid[i,j] = gameObject.transform.GetChild(c).gameObject.transform.GetComponent<Grid>();
                    mineGrid[i, j].position_X = i;
                    mineGrid[i, j].position_Y = j;
                    mines[i, j] = 0;
                }
            }

            //埋炸彈
            for (int i = 0; i < minesCount; i++)
            {
                int x = Random.Range(0,5);
                int y = Random.Range(0,5);

                mines[x,y] = 1;
                mineGrid[x, y].item.alpha = 1;
                mineGrid[x, y].around.alpha = 0;
            }
        }

        public void Click(int x, int y)
        {
            mineGrid[x, y].cover.alpha = 0;
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
                    mineGrid[x, y].around.alpha = 1;
                    mineGrid[x, y].around_TMP.text = count.ToString();
                }
            }
            else if (mines[x, y] == 1)
            {
                Debug.Log("地雷");
            }
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