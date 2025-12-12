using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lodiya
{
    public class GameManager : MonoBehaviour
    {
        public Camera cam;
        public GraphicRaycaster raycaster;
        public EventSystem eventSystem;

        [SerializeField]
        public TMP_Text hp_Text;

        [SerializeField]
        public int hpMax = 5;
        public int hp;

        void Start()
        {
            hp = hpMax;
        }

        public void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("點擊了右鍵");

                RaycastUI();
            }
        }

        /// <summary>
        /// 增減生命值
        /// </summary>
        /// <param name="damage">增減的數值</param>
        public void UpdateHP(int damage)
        {
            hp += damage;
            hp_Text.text = $"{hp}/{hpMax}"; 

            if (hp <= 0) Debug.Log($"<color=#f00>遊戲結束"); 
        }

        /// <summary>
        /// 右鍵點擊
        /// </summary>        
        private void RaycastUI()
        {
            PointerEventData pointerData = new PointerEventData(eventSystem);
            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            raycaster.Raycast(pointerData, results);

            for (int i = 0; i < results.Count; i++)
            {
                RaycastResult result = results[i];
                Debug.Log($"<color=#6f6>{result.gameObject.name}</color>");

                if (result.gameObject.TryGetComponent(out Grid_Canvas grid))
                {
                    grid.Test();
                }
            }

            if (results.Count > 0)
            {
                GameObject hit = results[2].gameObject;
                Debug.Log("點到 UI 元件: " + hit.name);

                Grid_Canvas grid = hit.GetComponent<Grid_Canvas>();

                if (grid != null)
                {
                    grid.Mark();
                }
            }
        }
    }
}
