using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
        /// <summary>
        /// 生命值最高上限
        /// </summary>
        private int hpLimit = 10;   
        public int hp;

        public int shield;

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
        /// <param name="damage">增減的數值</param>
        public void Damage(int damage)
        {
            Debug.Log($"受到{damage}點傷害");

            if (shield > 0)
            {
                if(shield > damage)
                {
                    shield -= damage;
                }
                else
                {
                    hp = (hp + shield) - damage;
                    shield = 0;
                }
            }
            else
            {
                hp -= damage;
            }

            SetHP();

            if (hp <= 0) Debug.Log($"<color=#f00>遊戲結束"); 
        }

        /// <summary>
        /// 回復生命值
        /// </summary>
        /// <param name="value">增減的數值</param>
        public void Heal(int value)
        {
            hp += value;
            SetHP();
        }

        /// <summary>
        /// 生命值上限
        /// </summary>
        /// <param name="value"></param>
        public void SetHPMax(int value)
        {
            if (hpMax < hpLimit)
                hpMax = hpMax + value;
            else Debug.Log("生命值已達上限");

            SetHP();
        }

        /// <summary>
        /// 護盾
        /// </summary>
        /// <param name="value"></param>
        public void SetShield(int value)
        {
            shield += value;

            SetHP();
        }

        public void SetHP()
        {
            if(shield > 0)
            {
                hp_Text.text = $"{hp}/{hpMax}({shield})";
            }
            else
            {
                hp_Text.text = $"{hp}/{hpMax}";
            }
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
