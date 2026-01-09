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

        public CanvasGroup canvas;
        //private bool open;

        private void Awake()
        {
            btu.onClick.AddListener(() =>
                List());
        }

        public void GetItem(Item _item)
        {
            item = _item;
            slotImg.sprite = _item.img;

            //btu.onClick.AddListener(() =>
                //OpenList());
            //Debug.Log("設定為開啟");
        }

        public void UseItem()
        {
            if(item == null) return;

            Debug.Log("使用物品");

            item.Use();
            if (item is Consumables)
                ItemManager.instance.ItemSlotLose(slot);
        }

        public void LoseItem() 
        {
            if(item == null) return;

            if (item.canLeave)
            {
                item = null;
                slotImg.sprite = null;
            }
            illustrate.instance.CloseCanvas();
        }

        private void OpenList()
        {
            illustrate.instance.GetItem(this);

            illustrate.instance.useItem = UseItem;
            illustrate.instance.loseItem = LoseItem;

            Debug.Log("設定為關閉");
        }

        public void CloseList() 
        {
            illustrate.instance.CloseCanvas();

            Debug.Log("設定為開啟");
        }

        public void List()
        {
            if (!illustrate.instance.open) OpenList();
            else CloseList();
        }
    }
}