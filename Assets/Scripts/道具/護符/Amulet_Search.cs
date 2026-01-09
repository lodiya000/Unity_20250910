using System;
using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 探測護符
    /// </summary>
    [Serializable, CreateAssetMenu(menuName = "Lodiya/Amulet/Search", order = 0)]
    public class Amulet_Search : Amulet
    {
        public override void GetAmulet()
        {
            base.GetAmulet();

            MinesManager.instance.item_Search = true;
        }

        public override void DropAmulet()
        {
            base.DropAmulet();

            MinesManager.instance.item_Search = false;
        }
    }
}