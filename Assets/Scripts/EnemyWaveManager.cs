using System;
using UnityEngine;

namespace TowerDefense
{
    public class EnemyWaveManager : MonoBehaviour
    {
        [SerializeField] private Enemy m_enemyPrefabs;
        [SerializeField] private Path[] m_paths;
        [SerializeField] private EnemyWave m_currentWave;

        public event Action OnAllWavesDead;
        public EnemyWave CurrentWave => m_currentWave;

        private int m_activeEnemyCount;

        private void Start()
        {
            m_currentWave.Prepare(SpwanEnemies);
        }
        public void ForceNextWave()
        {
            if (m_currentWave)
            {
                TDPlayer.Instance.ChangeGold((int)m_currentWave.GetRemainingTime());
                SpwanEnemies();
            }
            else
            {
                if (m_activeEnemyCount == 0)
                    
                OnAllWavesDead?.Invoke();
            }
        }

        private void RecordEnemyDead()
        {
            if (--m_activeEnemyCount == 0) // сначала удаляет, потом проверяет. 
            {
                ForceNextWave();

            }

        }
        private void SpwanEnemies()
        {
            foreach ((EnemyAsset asset, int count, int pathIndex) in m_currentWave.EnumerateSquads())
            {
                if (pathIndex < m_paths.Length)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var enemy = Instantiate(m_enemyPrefabs, m_paths[pathIndex].StartArea.RandomInsideZone, Quaternion.identity);
                        enemy.OnEnemyDestroy += RecordEnemyDead;
                        enemy.Use(asset);
                        enemy.GetComponent<TDPatrolController>().SetPath(m_paths[pathIndex]);
                        m_activeEnemyCount += 1;
                    }
                }
                else
                {
                    Debug.Log($"Invalid pathIndex in {name}");
                }
            }
            // create enemy
            m_currentWave = m_currentWave.PrepareNext(SpwanEnemies);
        }
    }
}