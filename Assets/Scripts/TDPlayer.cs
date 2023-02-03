using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class TDPlayer : MonoSingleton<TDPlayer>
    {
        [SerializeField] private int m_gold = 0;
        [SerializeField] private int m_NumLives;

        private static event Action<int> OnGoldUpdate;
        public static void GoldUpdateSubscribe(Action<int> act)
        {
            OnGoldUpdate += act;
            act(Instance.m_gold);
        }

        private static event Action<int> OnLifeUpdate;
        public static void LifeUpdateSubscribe(Action<int> act)
        {
            OnLifeUpdate += act;
            act(Instance.m_NumLives);
        }
        public void ChangeGold(int change)
        {
            m_gold += change;
            OnGoldUpdate(m_gold);
        }

        public void TakeDamage(int m_damage)
        {
            m_NumLives -= m_damage;
            OnLifeUpdate(m_NumLives);
            if (m_NumLives <= 0)
            {
                LevelSequenceController.Instance.FinishCurrentLevel(false);
            }
        }
        // верим в то, что золота на постройку достаточно. 
        [SerializeField] private Tower m_towerPrefab;
        public void TryBuild(TowerAsset m_TowerAsset, Transform buildSite)
        {
            ChangeGold(-m_TowerAsset.goldCost);
            var tower = Instantiate(m_towerPrefab, buildSite.position, Quaternion.identity);

            tower.GetComponentInChildren<SpriteRenderer>().sprite = m_TowerAsset.sprite;

            Destroy(buildSite.gameObject);
        }
    }
}