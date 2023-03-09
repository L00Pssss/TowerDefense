using UnityEngine;

namespace TowerDefense
{
    public class TDProjectile : Projectile
    {
        public enum DamageType { Base, Magic }
        [SerializeField] private DamageType m_damageType;
        protected override void OnHit(RaycastHit2D hit)
        {
            
            if (hit)
            {
                var enemy = hit.collider.transform.root.GetComponent<Enemy>();

                if (enemy != null)
                {
                    enemy.TakeDamage(m_Damage);
                }
            }
        }
    }
}