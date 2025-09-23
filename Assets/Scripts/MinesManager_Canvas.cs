using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Lodiya
{
    public class MinesManager_Canvas : MonoBehaviour
    {
        [SerializeField]
        //炸彈數量
        public int minesCount = 10;
        [SerializeField]
        public GameObject baseBox;
        public int[,] mines = new int[5, 5];
        //沒炸彈為0 炸彈為1 道具
        public Grid_Canvas[,] mineGrid = new Grid_Canvas[5, 5];
        private Grid_Canvas grid;

        [SerializeField]
        public Sprite[] num = new Sprite[9];
        [SerializeField]
        public Sprite bomb;

        private void Awake()
        {
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    int c = x * 5 + y;
                    mineGrid[x, y] = gameObject.transform.GetChild(c).gameObject.transform.GetComponent<Grid_Canvas>();
                    mineGrid[x, y].SetPosition(x, y);
                    mines[x, y] = 0;

                    mineGrid[x, y].item.sprite = null;
                }
            }

            //埋炸彈
            for (int i = 0; i < minesCount; i++)
            {
                int x = Random.Range(0, 5);
                int y = Random.Range(0, 5);

                mines[x, y] = 1;
                mineGrid[x, y].item.sprite = bomb;
            }
        }

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
                    mineGrid[x, y].item.sprite = num[count - 1];
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