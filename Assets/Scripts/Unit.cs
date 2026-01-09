using UnityEngine;

namespace Lodiya
{

    /// <summary>
    /// 敵人跟道具的基本單元
    /// 用來掛在格子上面
    /// </summary>
    public class Unit : ScriptableObject
    {
        /// <summary>
        /// 圖片
        /// </summary>
        public Sprite img;

        public virtual void flip()
        {

        }
    }
}