using UnityEngine;
using TMPro;

namespace TowerDefense {
    public class NextWaveGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_bonusAmount;
        private EnemyWaveManager m_manager;
        private float m_timeToNextWave;
        private void Start()
        {
            m_manager = FindObjectOfType<EnemyWaveManager>();
            EnemyWave.OnWavePrepare += (float time) =>
            {
                m_timeToNextWave = time;
            };
        }
        private void Update()
        {
            var bonus = (int)m_timeToNextWave;
            if (bonus < 0) bonus = 0;

            m_bonusAmount.text = bonus.ToString();
            m_timeToNextWave -= Time.deltaTime;

            if (m_manager.CurrentWave == null)
            {
                m_timeToNextWave = 0;
            }
        }

        public void CallWave()
        {
            m_manager.ForceNextWave();
        }   
    }
}