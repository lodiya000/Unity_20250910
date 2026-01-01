using UnityEngine;

namespace Lodiya
{
    [CreateAssetMenu(fileName = "DataWave", menuName = "Lodiya/DataWave", order = 2)]
    public class WaveData : ScriptableObject
    {
        //怪物(關卡資料)
        public Enemy[] enemy;
        //道具
        public Item[] items;
    }
}