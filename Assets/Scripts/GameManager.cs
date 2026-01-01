using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Lodiya
{
    public class GameManager : MonoBehaviour
    {
        #region 單例模式
        //單例模式: 此物件只有一個存在且須要讓其他物件存取時使用
        //存放此物件的容器
        private static GameManager _instance;
        //讓外部取得的窗口 (唯獨)
        public static GameManager instance
        {
            get
            {
                if (_instance == null) _instance = FindAnyObjectByType<GameManager>();

                return _instance;
            }
        }
        #endregion


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
            hp_Text.text = $"{hp}/{hpMax}";
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
        /// 減少生命值
        /// </summary>
        /// <param name="value">增減的數值</param>
        public void Damage(int value)
        {
            hp -= value;
            hp_Text.text = $"{hp}/{hpMax}"; 

            if (hp <= 0) Debug.Log($"<color=#f00>遊戲結束"); 
        }

        /// <summary>
        /// 回復生命值
        /// </summary>
        /// <param name="value">增減的數值</param>
        public void Heal(int value)
        {
            hp += value;
            hp_Text.text = $"{hp}/{hpMax}";

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

                if(result.gameObject.TryGetComponent(out Grid grid))
                {
                    Debug.Log("點到 UI 元件: " + grid.name);

                    grid.Mark();
                }
            }
        }
    }
}
