using Lodiya;
using UnityEngine;
using System.Collections.Generic;
using Grid = Lodiya.Grid;

namespace KID
{
    /// <summary>
    /// 地格生成器
    /// </summary>
    public class GridSpawner : MonoBehaviour
    {
        private static GridSpawner _instance;
        private static GridSpawner instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<GridSpawner>();
                return _instance;
            }
        }

        [SerializeField, Range(1, 10)]
        private int width = 5;
        [SerializeField, Range(1, 10)]
        private int height = 5;
        [SerializeField]
        private Grid prefabGrid;
        [SerializeField]
        private Transform gridParent;
        [SerializeField]
        private List<Grid> allGrids = new List<Grid>();

        private void Awake()
        {
            Spawn();
        }

        /// <summary>
        /// 生成
        /// </summary>
        private void Spawn()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Grid temp = Instantiate(prefabGrid, gridParent);
                    allGrids.Add(temp);
                }
            }
        }
    }
}
