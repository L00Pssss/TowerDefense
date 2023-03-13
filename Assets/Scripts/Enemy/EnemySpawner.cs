using UnityEngine;

namespace TowerDefense
{

    public class EnemySpawner : Spawner
    {
        /// <summary>
        /// Ссылки на то что спавнить.
        /// </summary>
        [SerializeField] private Enemy m_EntityPrefabs;
        [SerializeField] private Path m_path;
        [SerializeField] private EnemyAsset[] m_EnemyAsset;

        public EnemyAsset[] EnemyNumber
        {
            get { return m_EnemyAsset; }
            set { m_EnemyAsset = value; }
        }

        protected override GameObject GenerateSpawnedEntity()
        {
            var enemy = Instantiate(m_EntityPrefabs);
            enemy.Use(m_EnemyAsset[Random.Range(0, m_EnemyAsset.Length)]);

            enemy.GetComponent<TDPatrolController>().SetPath(m_path);

            return enemy.gameObject;
        }
    }
}