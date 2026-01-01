using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 護符
    /// </summary>
    public class Amulet : Item
    {
        protected void Awake()
        {
            canUse = false;

            canLeave = true;
        }

        protected virtual void GetAmulet()
        {

        }

        protected virtual void DropAmulet()
        {

        }    
    }
}