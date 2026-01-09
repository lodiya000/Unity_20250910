using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
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

        public void GetItem(ItemSlot _slot)
        {
            slot = _slot;

            TakeItem();
        }

        private void TakeItem()
        {
            StartCoroutine(FadeSystam.Fade(_canvasGroup));
            Debug.Log("open");

            itemImage.sprite = slot.item.img;
            itemName.text = slot.item.itemName;
            itemText.text = slot.item.itemEffect;

            if (slot.item.canUse)
            {
                StartCoroutine(FadeSystam.Fade(useCanvas));

                useBtu.onClick.AddListener(() =>
                slot.UseItem());
            }
            else StartCoroutine(FadeSystam.Fade(useCanvas, 0, false));


            if (slot.item.canLeave)
            {
                StartCoroutine(FadeSystam.Fade(dropCanvas));

                dropBtu.onClick.AddListener(() =>
                    slot.LoseItem());
            }
            else StartCoroutine(FadeSystam.Fade(dropCanvas, 0, false));
        }

        public void CloseCanvas()
        {
            slot = null;
            StartCoroutine(FadeSystam.Fade(_canvasGroup, 0, false));
            Debug.Log("close");
        }
    }
}