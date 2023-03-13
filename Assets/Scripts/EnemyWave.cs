using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemyWave : MonoBehaviour
    { 
        [Serializable]
        private class Squad // волны. 
        {
            public EnemyAsset asset;
            public int count;
        }
        [Serializable]
        private class PathGroup // группа волн
        {
            public Squad[] squads;
        }

        public static Action<float> OnWavePrepare;
        private event Action OnWaveReady;
        [SerializeField] private PathGroup[] m_groups; // должно синхр с Path[] m_paths; в менеджере через инспектор.
        [SerializeField] private float m_prepareTime = 10;
        [SerializeField] private EnemyWave m_next;
        public float GetRemainingTime() { return m_prepareTime - Time.time; } 

        private void Awake()
        {
            enabled = false;
        }
        private void Update()
        {
            if (Time.time > m_prepareTime)
            {
                enabled = false;
                OnWaveReady?.Invoke();
            }
        } 
        public void Prepare(Action spwanEnemies)
        {
            OnWavePrepare?.Invoke(m_prepareTime);
            m_prepareTime += Time.time;
            enabled = true;
            OnWaveReady += spwanEnemies;
        }
        public IEnumerable<(EnemyAsset asset, int count, int pathIndex)> EnumerateSquads()
        {
            for (int i = 0; i < m_groups.Length; i++)
            {
                foreach (var squad in m_groups[i].squads)
                {
                    yield return (squad.asset, squad.count, i);
                }
            }
        }    
        public EnemyWave PrepareNext(Action spwanEnemies)
        {
            OnWaveReady -= spwanEnemies;
            if(m_next) m_next.Prepare(spwanEnemies);
            return m_next;
        }
    }
}