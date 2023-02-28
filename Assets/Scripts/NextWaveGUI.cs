using UnityEngine;
using TMPro;

namespace TowerDefense {
    public class NextWaveGUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI m_BonusAmount;
        private EnemyWaveManager m_manager;
        private float m_timeToNextWave;
        void Start()
        {
            m_manager = FindObjectOfType<EnemyWaveManager>();
            EnemyWave.OnWavePrepare += (float time) =>
            {
                m_timeToNextWave = time;
            };
        }

        public void CallWave()
        {
            m_manager.ForceNextWave();
        }

        private void Update()
        {
            var bonus = (int)m_timeToNextWave;
            if (bonus < 0) bonus = 0;


            m_BonusAmount.text = ((int)m_timeToNextWave).ToString();
            
            m_timeToNextWave -= Time.deltaTime;
            
            
           
        }
    }
}