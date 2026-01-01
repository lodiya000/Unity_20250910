using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField]
        public Button btu;

        /// <summary>
        /// 儲存道具
        /// </summary>
        [SerializeField]
        public Item item;

        /// <summary>
        /// 道具欄圖片
        /// </summary>
        public Image slotImg;

        /// <summary>
        /// 格子編號
        /// </summary>
        [SerializeField]
        public int slot;


        public void GetItem(Item _item)
        {
            item = _item;
            slotImg.sprite = _item.img;

            if (item.canUse)
            {
                btu.onClick.AddListener(() =>
                    UseItem());
            }
            else Debug.Log("該物品不能使用");
        }

        public void UseItem()
        {
            Debug.Log("使用物品");
            if(item == null) return;
            item.Use();
            if (item is Consumables)
                ItemManager.instance.ItemSlotLose(slot);
        }

        public void LoseItem() 
        {
            if (item.canLeave)
            {
                item = null;
                slotImg.sprite = null;
            }


        }

    }
}