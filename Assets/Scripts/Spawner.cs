using UnityEngine;

namespace TowerDefense
{

    public abstract class Spawner : MonoBehaviour
    {
        protected abstract GameObject GenerateSpawnedEntity();
        /// <summary>
        /// Зона спавна.
        /// </summary>
        [SerializeField] private CircleArea m_area;

        [SerializeField] private SpawnMode m_spawnMode;

        /// <summary>
        /// Кол-во объектов которые будут разом заспавнены.
        /// </summary>
        [SerializeField] private int m_numSpawns;

        /// <summary>
        /// Время респавна. Здесь важно заметить что респавн таймер должен быть больше времени жизни объектов.
        /// </summary>
        [SerializeField] private float m_respawnTime;

        private float m_Timer;


        private void Start()
        {
            if (m_spawnMode == SpawnMode.Start)
            {
                SpawnEntities();
            }
        }

        private void Update()
        {
            if (m_Timer > 0)
                m_Timer -= Time.deltaTime;

            if (m_spawnMode == SpawnMode.Loop && m_Timer <= 0)
            {
                SpawnEntities();
                m_Timer = m_respawnTime;
            }
        }
        /// <summary>
        /// Режим спавна.
        /// </summary>
        public enum SpawnMode
        {
            /// <summary>
            /// На методе Start()
            /// </summary>
            Start,

            /// <summary>
            /// Периодически используя время m_RespawnTime
            /// </summary>
            Loop
        }
        private void SpawnEntities()
        {
            for(int i = 0; i < m_numSpawns; i++)
            {
                var e = GenerateSpawnedEntity();
                e.transform.position = m_area.RandomInsideZone;
            }
        }
    }
}