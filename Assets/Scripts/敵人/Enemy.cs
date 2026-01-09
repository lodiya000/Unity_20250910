namespace Lodiya
{
    public class Enemy : Unit
    {
        public int damage;

        /// <summary>
        /// 生成模式
        /// </summary>
        public virtual void SpwanMod(int gridCount)
        {

        }

        public override void flip()
        {
            GameManager.instance.Damage(damage);
        }
    }
}