using Unity.VisualScripting;
using UnityEngine;

namespace TowerDefense
{
    public class EnemyWaveManager : MonoBehaviour
    {
        [SerializeField] private Enemy m_EntityPrefabs;
        [SerializeField] private Path[] m_paths;
        [SerializeField] private EnemyWaves m_currentWave;

        private void Start()
        {
            m_currentWave.Prepare(SpwanEnemies);
        }

        private void SpwanEnemies()
        {
            foreach ((EnemyAsset asset, int count, int pathIndex) in m_currentWave.EnumerateSquads())
            {
                if (pathIndex < m_paths.Length)
                {
                    for (int i = count; i < count; i++)
                    {
                        var enemy = Instantiate(m_EntityPrefabs);
                        enemy.Use(asset);

                        enemy.GetComponent<TDPatrolController>().SetPath(m_paths[pathIndex]);
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