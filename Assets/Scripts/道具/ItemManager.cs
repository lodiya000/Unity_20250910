using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 道具管理器
    /// </summary>
    public class ItemManager : MonoBehaviour
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static ItemManager _instance;
        //讓外部取得的窗口 (唯獨)
        public static ItemManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<ItemManager>();

                return _instance;
            }
        }
        #endregion

        public int bag = 5;
        private int itemMax = 10;

        private ItemSlot[] slots = new ItemSlot[10];

        private int count = 0;

        private void Awake()
        {
            for (int i = 0; i < itemMax; i++)
            {
                slots[i] = gameObject.transform.GetChild(i).
                    gameObject.transform.GetComponent<ItemSlot>();
                if(i >= bag)
                    slots[i].canvas.alpha = 0;

            }
        }

        public void ItemSlotGet(Item item)
        {
            if (count < bag)
            {
                slots[count].GetItem(item);
                item.GetAmulet();
                count++;
            }
            else Debug.Log("背包空間不足");
        }

        public void ItemSlotUse(int id)
        {
            if (slots[id].item.canUse)
            {
                slots[id].item.Use();

                slots[id].slotImg.sprite = null;
            }
            else Debug.Log("該物品不能使用");
        }

        public void ItemSlotLose(int id)
        {
            slots[id].LoseItem();
            if (slots[id].item != null)
                slots[id].item.DropAmulet();
            //else Debug.Log("該物品不能丟棄");
        }

        public void SetBag()
        {
            if (bag < itemMax)
            { 
                bag++;
                slots[bag].canvas.alpha = 1;
            }
        }
    }
}