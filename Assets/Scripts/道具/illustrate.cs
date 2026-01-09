using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    public class illustrate : MonoBehaviour
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static illustrate _instance;
        //讓外部取得的窗口 (唯獨)
        public static illustrate instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<illustrate>();

                return _instance;
            }
        }
        #endregion

        [SerializeField]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        private Image itemImage;    ///道具圖

        [SerializeField]
        private TMP_Text itemName;  ///道具名
        
        [SerializeField]
        private TMP_Text itemText;  ///說明文

        [SerializeField]
        private Button useBtu;      ///使用鈕
        [SerializeField]
        private CanvasGroup useCanvas;

        [SerializeField]
        private Button dropBtu;     ///丟棄鈕
        [SerializeField]
        private CanvasGroup dropCanvas;

        [SerializeField]
        private ItemSlot slot;

        public void TakeItem(ItemSlot _slot)
        {
            slot = _slot;

            TakeItem();

        }

        private void TakeItem()
        {
            _canvasGroup.alpha = 1;

            itemImage.sprite = slot.item.img;
            itemName.text = slot.item.itemName;
            itemText.text = slot.item.itemEffect;

            if (slot.item.canUse)
            {
                useCanvas.alpha = 1;

                useBtu.onClick.AddListener(() =>
                slot.UseItem());
            }
            else useCanvas.alpha = 0;

            if (slot.item.canLeave)
            {
                dropCanvas.alpha = 1;

                dropBtu.onClick.AddListener(() =>
                    slot.LoseItem());
            }
            else dropCanvas.alpha = 0;
        }

        public void CloseCanvas()
        {
            _canvasGroup.alpha = 0;
        }
    }
}