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

        public static event Action<int> OnGoldUpdate;
        public static event Action<int> OnLifeUpdate;
        private void Start()
        {
            OnGoldUpdate(m_gold);
            OnLifeUpdate(m_NumLives);
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
    }
}