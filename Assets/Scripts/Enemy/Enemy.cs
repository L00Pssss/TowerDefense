using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;

namespace TowerDefense
{
    [RequireComponent(typeof(TDPatrolController))]
    [RequireComponent(typeof(Destructible))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int m_damage = 1;
        [SerializeField] private int m_gold = 1;
        [SerializeField] private int m_armor = 1;
        [SerializeField] private ArmorType m_armorType;

        public event Action OnEnemyDestroy;

        private Destructible m_Destructible;

        private void Awake()
        {
            m_Destructible= GetComponent<Destructible>();
        }

        private void OnDestroy()
        {
           OnEnemyDestroy?.Invoke();
        }

        public void Use(EnemyAsset asset)
        {
            var spriteRenderer = transform.Find("Sprite").GetComponent<SpriteRenderer>();
            spriteRenderer.color = asset.color;
            spriteRenderer.transform.localScale = new Vector3(asset.sprtiteScale.x, asset.sprtiteScale.y, 1);

            spriteRenderer.GetComponent<Animator>().runtimeAnimatorController = asset.animations;
            // хп (в спейсшипе преопределяется)
            GetComponent<SpaceShip>().Use(asset);

            GetComponentInChildren<CircleCollider2D>().radius = asset.radius;

            GetComponentInChildren<CircleCollider2D>().offset = asset.offset;


            if (asset.FlipY == true)
            {
                spriteRenderer.flipY = asset.FlipY = true;
            }

            m_damage = asset.damage;
            m_armor = asset.armor;
            m_gold = asset.gold;
            m_armorType = asset.arrmorType;
        }

        public void DamagePlayer()
        {
            TDPlayer.Instance.TakeDamage(m_damage);
        }

        public void GivePlayerGold ()
        {
           TDPlayer.Instance.ChangeGold(m_gold);
        }

        public void TakeDamage(int damage, TDProjectile.DamageType damageType)
        {
            m_Destructible.ApplyDamage(ArmorDamageFunctions[(int)m_armorType](damage,damageType,m_armor));
        }

        public enum ArmorType { Base = 0, Mage = 1 }

        private static Func<int, TDProjectile.DamageType, int, int>[] ArmorDamageFunctions =
        {
            (int power, TDProjectile.DamageType type, int armor) =>
            { // ArmomrType.Base
                switch (type)
                {
                    case TDProjectile.DamageType.Magic: return power;
                    default: return Mathf.Max(power- armor, 1);
                }
            },
            (int power, TDProjectile.DamageType type, int armor) =>
            { // ArmomrType.Base
                    if(TDProjectile.DamageType.Base == type)
                    armor = armor / 2;
                    return Mathf.Max(power - armor, 1 );

            },

        };
    }

#if UNITY_EDITOR


    [CustomEditor(typeof(Enemy))]
    public class EnemyInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            // стандарный ГУИ base.OnInspectorGUI();
            base.OnInspectorGUI();
            GUILayout.Label("heya");
            EnemyAsset a = EditorGUILayout.ObjectField(null, typeof(EnemyAsset), false) as EnemyAsset;

            if (a)
            {
                (target as Enemy).Use(a);
            }
        }
    }
#endif
}