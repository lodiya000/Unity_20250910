using System;
using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 治療藥水
    /// </summary>
    [Serializable, CreateAssetMenu(menuName = "Lodiya/Consumables/Shield", order = 0)]
    public class Shield : Consumables
    {
        [SerializeField]
        public int value;

        public override void Use()
        {
            base.Use();

            GameManager.instance.SetShield(value);
        }
    }
}