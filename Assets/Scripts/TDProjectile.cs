using UnityEngine;

namespace TowerDefense
{
    public class TDProjectile : Projectile
    {
        [SerializeField] private DamageType m_damageType;
        public enum DamageType { Base, Magic }      
        protected override void OnHit(RaycastHit2D hit)
        {
            var enemy = hit.collider.transform.root.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(m_Damage, m_damageType);
            }
        }
    }
}