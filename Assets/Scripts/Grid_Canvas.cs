using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Lodiya
{
    public class Grid_Canvas : MonoBehaviour
    {
        [SerializeField]
        MinesManager_Canvas minesManager;

        [SerializeField]
        public Button btu;

        [SerializeField]
        public Image item;

        [SerializeField]
        public Image cover;
        [SerializeField]
        public GameObject _cover;

        public bool canOpen = true;

        private int position_X, position_Y;

        private void Awake()
        {
            btu.onClick.AddListener(() => minesManager.Click(position_X, position_Y));
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
        }
    }
}

