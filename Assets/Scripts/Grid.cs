using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Lodiya
{
    public class Grid : MonoBehaviour
    {
        [SerializeField]
        MinesManager minesManager;

        [SerializeField]
        public SpriteRenderer item;

        [SerializeField]
        public SpriteRenderer cover;

        public bool canOpen = true;

        private int position_X, position_Y;

        private void Awake()
        {

        }

        public void SetPosition(int x, int y)
        {
            position_X = x;
            position_Y = y;
        }

        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0) && canOpen) // 0 = 左鍵
                minesManager.Click(position_X, position_Y);
            else if (Input.GetMouseButtonDown(1)) // 1 = 右鍵
                minesManager.Mark(position_X, position_Y);
        }
    }
}