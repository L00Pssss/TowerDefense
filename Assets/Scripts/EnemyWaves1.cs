using System;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemyWaves : MonoBehaviour
    {
        [SerializeField] private float m_prepareTime = 10;

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

        private event Action OnWaveReady;
        public void Prepare(Action spwanEnemies)
        {
            m_prepareTime += Time.time;
            enabled = true;
            OnWaveReady += spwanEnemies;
        }
        public IEnumerable<(EnemyAsset asset, int count, int pathIndex)> EnumerateSquads()
        {
            throw new NotImplementedException();
        }
        internal EnemyWaves PrepareNext(Action spwanEnemies)
        {
            throw new NotImplementedException();
        }
    }
}