using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    /// <summary>
    /// 關卡生成器
    /// </summary>
    public class SceneGeneration : MonoBehaviour
    {
        [SerializeField]
        private WaveData waveData;
        [SerializeField]
        private GameObject grid;
        [SerializeField]
        private Transform bottom;
        [SerializeField]
        private GridLayoutGroup group;

        private void Awake()
        {
            /*
            if(bottom.ChildCount <= 0)
            {

            }*/
            int c = 650 / waveData.GridCount;
            group.cellSize = new Vector2(c, c);

            for (int x = 0; x < waveData.GridCount; x++)
            {
                for (int y = 0; y < waveData.GridCount; y++)
                {
                    Instantiate(grid, bottom);
                }
            }

            MinesManager.instance.GenerationAwake();
        }
    }
}