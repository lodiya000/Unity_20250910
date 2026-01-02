using System;
using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 體力強化劑
    /// 生命值上限+1(最高10)
    /// </summary>
    [Serializable, CreateAssetMenu(menuName = "Lodiya/Consumables/Fortifier", order = 0)]
    public class Fortifier : Consumables
    {
        [SerializeField]
        public int value;

        public override void Use()
        {
            base.Use();

            GameManager.instance.SetHPMax(value);
        }
    }
}