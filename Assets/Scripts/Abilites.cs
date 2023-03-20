using System.Collections;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Drawing;
using Color = UnityEngine.Color;

namespace TowerDefense
{
    public class Abilites : MonoSingleton<Abilites>
    {
        [Serializable]
        public class FireAbility
        {
            [SerializeField] private int m_Cost = 5;
            [SerializeField] private int m_Damage = 5;
            [SerializeField] private Color m_TargetingColor;

            public int Damage
            {
                get { return m_Damage; }
                set { m_Damage = value; }
            }
            public void Use()
            {
                ClickProtection.Instance.Activate((Vector2 v) =>
                {
                    Vector3 postion = v;
                    postion.z = -Camera.main.transform.position.z;
                    postion = Camera.main.ScreenToWorldPoint(postion);
                    
                    foreach (var collider in Physics2D.OverlapCircleAll(postion, 5))
                    {
                        if (collider.transform.parent.TryGetComponent<Enemy>(out var enemy))
                        {
                            enemy.TakeDamage(m_Damage, TDProjectile.DamageType.Magic);
                        }
                    }
                });
            }

        }
        [Serializable]
        public class TimeAbility
        {
            [SerializeField] private int m_Cost = 10;
            [SerializeField] private int m_Cooldown = 10;
            [SerializeField] private float m_Duration = 5;

            public void Use()
            {
                void Slow(Enemy enemy)
                {
                    enemy.GetComponent<SpaceShip>().HalfMaxLinearVelocity();
                }
             

                foreach (var ship in FindObjectsOfType<SpaceShip>())
                {
                    ship.HalfMaxLinearVelocity();
                }
                EnemyWaveManager.OnEnemySwpan += Slow;

                IEnumerator Restore()
                {
                    yield return new WaitForSeconds(m_Duration);
                    foreach (var ship in FindObjectsOfType<SpaceShip>())
                    {
                        ship.RestoreMaxLinerVelocity();
                    }
                    EnemyWaveManager.OnEnemySwpan -= Slow;
                }
                Instance.StartCoroutine(Restore());

                IEnumerator TimeAbilityButton()
                {
                    Instance.m_TimButton.interactable = false;
                    yield return new WaitForSeconds(m_Cooldown);
                    Instance.m_TimButton.interactable = true;
                }
                Instance.StartCoroutine(TimeAbilityButton());

            }

        }
        [SerializeField] private UpgradeAsset_UI[] m_upgrade;
        [SerializeField] private Button m_TimButton;
        [SerializeField] private Button m_FireButton;
        [SerializeField] private Image m_TargetingCircle;
        [SerializeField] private FireAbility m_FireAbility;
        [SerializeField] private TimeAbility m_TimeAbility;
        public void UseFireAbility() => m_FireAbility.Use();
        
        public void useTimeAbility() => m_TimeAbility.Use();

        private new void Awake()
        {
            base.Awake();
            if (m_upgrade.Length != 0)
            {
                var Fire = Upgrades.GetUpgradeLevel(m_upgrade[0]);
                var Time = Upgrades.GetUpgradeLevel(m_upgrade[1]);
                Debug.Log(Fire);
                if (Fire <= 0)
                {
                   m_FireButton.interactable = false;
                }
                if (Time <= 0)
                {
                    m_TimButton.interactable = false;
                }

                if (Fire > 0)
                {
                    if (Fire > 1)
                    {
                        Instance.m_FireAbility.Damage = 5;
                    }
                    m_FireButton.interactable = true;
                }
                if (Time > 0)
                {
                    m_TimButton.interactable = true;
                }
            }
        }

    }
}