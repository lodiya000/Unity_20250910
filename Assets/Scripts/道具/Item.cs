using UnityEngine;

namespace Lodiya
{
    [SerializeField, CreateAssetMenu(menuName = "Lodiya/Item", order = 0)]
    public class Item : ScriptableObject
    {
        public string itemName;

        public int itemID;

        public bool canUse;
    }
}