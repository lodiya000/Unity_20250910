using UnityEngine;
using Random = UnityEngine.Random;

namespace Lodiya
{
    [SerializeField, CreateAssetMenu(menuName = "Lodiya/Enemy/1b", order = 0)]
    public class Enemy_1b : Enemy
    {
        private int x, y;

        public override void SpwanMod(int gridCount)
        {
            x = Random.Range(0, gridCount);
            y = Random.Range(0, gridCount);

            Grid grid = MinesManager.instance.mineGrid[x, y];

            if(grid)

            MinesManager.instance.mines[x, y] = 1;
            //MinesManager.instance.mineGrid[x, y].gridImg.sprite = img;
            MinesManager.instance.mineGrid[x, y].SetUnit(this);


            Debug.Log($"敵人座標{x},{y}");
        }

        public override void flip()
        {
            base.flip();

            Debug.Log($"遇到了{name}");
        }
    }
}