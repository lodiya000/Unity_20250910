using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Lodiya
{
    [Serializable, CreateAssetMenu(menuName = "Lodiya/Enemy/1b", order = 0)]
    public class Enemy_1b : Enemy
    {
        private int x, y;

        public override void SpwanMod(int gridCount)
        {
            x = Random.Range(0, gridCount);
            y = Random.Range(0, gridCount);

            Grid grid = MinesManager.instance.mineGrid[x, y];

            if (grid.unit == null)
            {
                MinesManager.instance.mines[x, y] = 1;
                MinesManager.instance.uints[x, y] = unit.Enemy;
                MinesManager.instance.mineGrid[x, y].SetUnit(this);
                Debug.Log($"敵人座標{x},{y}");
            }
            else 
            {
                Debug.Log($"重疊 重新設定");
                SpwanMod(gridCount); 
            }
        }

        public override void flip()
        {
            base.flip();

            Debug.Log($"遇到了{name}");
        }
    }
}