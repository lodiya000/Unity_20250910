using System;
using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 治療藥水
    /// </summary>
    [Serializable, CreateAssetMenu(menuName = "Lodiya/Consumables/bag", order = 0)]
    public class bag : Consumables
    {
        public override void Use()
        {
            base.Use();

            ItemManager.instance.SetBag();
        }
    }
}