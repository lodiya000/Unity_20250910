using UnityEngine;

namespace Lodiya
{
    public class Enemy : Unit
    {
        public int damage;

        private bool isFlip = false;

        /// <summary>
        /// 生成模式
        /// </summary>
        public virtual void SpwanMod(int gridCount)
        {

        }

        public override void flip()
        {
            if (!isFlip) 
                GameManager.instance.Damage(damage);

            isFlip = true;
        }
    }
}