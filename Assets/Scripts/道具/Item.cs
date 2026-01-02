using System;
using UnityEngine;

namespace Lodiya
{
    [Serializable, CreateAssetMenu(menuName = "Lodiya/Item", order = 0)]
    ///道具
    public class Item : Unit
    {
        /// <summary>
        /// 物品名稱
        /// </summary>
        protected string itemName;

        /// <summary>
        /// 物品ID
        /// </summary>
        protected int itemID;

        /// <summary>
        /// 能否使用
        /// </summary>
        public bool canUse;

        /// <summary>
        /// 能否主動丟掉
        /// </summary>
        public bool canLeave;

        /// <summary>
        /// 使用
        /// </summary>
        public virtual void Use()
        {
            if (!canUse)
            {
                Debug.Log("該物品不能使用"); 
            }
        }

        public virtual void SetItem(int x, int y)
        {
            //MinesManager.instance.mineGrid[x, y].gridImg.sprite = img;
            MinesManager.instance.mineGrid[x, y].SetUnit(this);
        }
    }
}