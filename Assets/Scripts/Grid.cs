using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        MinesManager m;
        [SerializeField]
        public Button btn;

        [SerializeField]
        public Image item_Img;
        [SerializeField]
        public CanvasGroup item;

        [SerializeField]
        public Image cover_Img;
        [SerializeField]
        public CanvasGroup cover;

        [SerializeField]
        public TMP_Text around_TMP;
        [SerializeField]
        public CanvasGroup around;
        public int position_X, position_Y;

        private void Awake()
        {
            btn.onClick.AddListener(() => m.Click(position_X, position_Y));
        }
    }
}