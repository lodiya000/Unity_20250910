using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        MinesManager minesManager;

        [SerializeField]
        public Button btu;

        [SerializeField]
        public Image gridImg;

        [SerializeField]
        public Unit unit;

        [SerializeField]
        public Image cover;
        [SerializeField]
        public GameObject _cover;
        [SerializeField]
        public CanvasGroup itemCanvas;

        [SerializeField]
        public TMP_Text num;

        public bool canOpen = true;
        public bool isFlip = false;
        private int position_X, position_Y;

        private void Awake()
        {
            btu.onClick.AddListener(() => MinesManager.instance.Flip(position_X, position_Y));
            itemCanvas.alpha = 0;
        }

        public void SetPosition(int x, int y)
        {
            position_X = x;
            position_Y = y;
        }

        public void Mark()
        {
            minesManager.Mark(position_X, position_Y);
        }

        public void Open()
        {
            _cover.SetActive(false);
            itemCanvas.alpha = 1;
        }

        public void Flip()
        {
            //Open();

            _cover.SetActive(false);

            if (unit != null)
            {
                unit.flip();
            
                if(unit is Item)
                {
                    Item _item = (Item)unit;
                    btu.onClick.AddListener(() =>
                         GetItem());
                }
                else if(unit is Enemy)
                {
                    btu.interactable = false;
                }
            }
        }

        private void GetItem()
        {
            Item _item = (Item)unit;
            ItemManager.instance.ItemSlotGet(_item);

            

            itemCanvas.alpha = 0;
            unit = null;
            gridImg.sprite = null;
        }

        public void SetUnit(Unit u)
        {
            itemCanvas.alpha = 1;
            unit = u;
            gridImg.sprite = u.img;
        }
    }
}

