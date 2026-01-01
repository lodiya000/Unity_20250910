using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 治療藥水
    /// </summary>
    [SerializeField, CreateAssetMenu(menuName = "Lodiya/Consumables/Potion", order = 0)]
    public class Potion : Consumables
    {
        [SerializeField]
        public int heal;

        public override void Use()
        {
            base.Use();

            GameManager.instance.Heal(heal);
        }
    }
}