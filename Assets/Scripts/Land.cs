using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    /// <summary>
    /// 地格
    /// </summary>
    public class Land
    {
        /// <summary>
        /// 座標 x,y
        /// </summary>
        public Vector2 location;

        public Image image;

        /// <summary>
        /// 地格的狀態
        /// 0 空白 1 炸彈 2 非正面道具/機關 3 正面道具/機關
        /// 探測時 用 A >= 1 表示有非空白格
        /// </summary>
        public int Mod;
    }
}