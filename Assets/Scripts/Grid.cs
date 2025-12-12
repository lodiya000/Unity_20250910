using UnityEngine;

namespace Lodiya
{
    public enum Type { None, Prop, Bomb }

    public class Content { }
    public class Enemy: Content { }
    public class Prop : Content { }

    public class Grid : MonoBehaviour
    {
        public void Initialize(Type _type, Content _content)
        {
            type = _type;
            content = _content;
        }

        private Type type;
        private Content content;

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