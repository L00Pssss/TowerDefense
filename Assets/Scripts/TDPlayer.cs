using System;
using UnityEngine;

namespace TowerDefense
{
    public class TDPlayer : MonoSingleton<TDPlayer>
    {
        [SerializeField] private int m_gold = 0;
        [SerializeField] private int m_NumLives;

        private static event Action<int> OnGoldUpdate;
        public event Action OnPlayerDead;
        public static void GoldUpdateSubscribe(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance.m_gold);
        }

        public static event Action<int> OnLifeUpdate;
        public static void LifeUpdateSubscribe(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance.m_NumLives);
        }

        public void GoldUpdateUnSubscribe(Action<int> act)
        {
            OnGoldUpdate -= act;
        } 
        //public void LifeUpdateUnSubscribe(Action<int> act)
        //{
        //    OnLifeUpdate -= act;
        //}
        public void ChangeGold(int change)
        {
            m_gold += change;
            OnGoldUpdate(m_gold);
        }



        public void TakeDamage(int damage)
        {
            m_NumLives -= damage;
            
            if (m_NumLives <= 0)
            {
                m_NumLives = 0;
                OnPlayerDead?.Invoke();
            }
            OnLifeUpdate(m_NumLives);
        }

        public void ChangeNumLivesWithUpgrade(int bounsLives)
        {
            m_NumLives += bounsLives;
        }


        // ����� � ��, ��� ������ �� ��������� ����������. 
        [SerializeField] private Tower m_towerPrefab;
        public void TryBuild(TowerAsset m_TowerAsset, Transform buildSite)
        {
            ChangeGold(-m_TowerAsset.goldCost);
            var tower = Instantiate(m_towerPrefab, buildSite.position, Quaternion.identity);

            tower.GetComponentInChildren<SpriteRenderer>().sprite = m_TowerAsset.sprite;

            tower.GetComponentInChildren<Turret>().Mode = m_TowerAsset.Mode;

            tower.GetComponentInChildren<Turret>().SetTurretProprties(m_TowerAsset.turretProperties);

            tower.GetComponent<Tower>().RadiusDetection = m_TowerAsset.RadiusDetection;

            if (m_TowerAsset.AddAnimationHero == true)
            {
                var pref = Instantiate(m_TowerAsset.PrefabAnimationHero, tower.GetComponent<Transform>().position, Quaternion.identity);
                pref.transform.parent = tower.transform.GetChild(0);
            }
            Destroy(buildSite.gameObject);
        }

        [SerializeField] private UpgradeAsset_UI[] m_Upgrade;
        private new void Awake()
        {
            base.Awake();
            var level = Upgrades.GetUpgradeLevel(m_Upgrade[0]);
            var gold = Upgrades.GetUpgradeLevel(m_Upgrade[1]);
            ChangeNumLivesWithUpgrade(level * 5);
            ChangeGold((int)((float)gold * 1.5f));
        }
    }
}