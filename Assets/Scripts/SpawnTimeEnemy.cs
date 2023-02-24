using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace TowerDefense
{
    public class SpawnTimeEnemy : MonoBehaviour
    {
        [SerializeField] List<EnemySpawner> EnemyList = new List<EnemySpawner>();

        [SerializeField] private int m_wave;

        [SerializeField ]private float time;

        private void Update()
        {
            time -= Time.deltaTime;
            if (time >= 0)
            {
               Wave_1();
            }
        }


        private void Wave_1()
        {
            if (Math.Round(time, 0) == 48)
            {
                EnemyList[0].gameObject.SetActive(false);
                EnemyList[1].gameObject.SetActive(true);     
            }
            if (Math.Round(time, 0) == 36)
            {
                EnemyList[1].gameObject.SetActive(false);
                EnemyList[2].gameObject.SetActive(true);
            }
            if (Math.Round(time, 0) == 24)
            {
                EnemyList[2].gameObject.SetActive(false);
                EnemyList[3].gameObject.SetActive(true);
            }
            if (Math.Round(time, 0) == 12)
            {
                EnemyList[3].gameObject.SetActive(false);
                EnemyList[4].gameObject.SetActive(true);
            }
            if (Math.Round(time, 0) == 0)
            {
                EnemyList[4].gameObject.SetActive(false);
            }
        }

        private void Wave_2()
        {
            if (Math.Round(time, 0) == 12)
            {
                EnemyList[0].enabled = false;
                EnemyList[1].enabled = false;
                EnemyList[2].enabled = true;
                EnemyList[3].enabled = true;
            }
            if (Math.Round(time, 0) == 24)
            {
                EnemyList[2].enabled = false;
                EnemyList[3].enabled = false;
                EnemyList[4].enabled = true;
                EnemyList[5].enabled = true;
            }
            if (Math.Round(time, 0) == 36)
            {
                EnemyList[4].enabled = false;
                EnemyList[5].enabled = false;
                EnemyList[6].enabled = true;
                EnemyList[7].enabled = true;
            }
            if (Math.Round(time, 0) == 48)
            {
                EnemyList[6].enabled = false;
                EnemyList[7].enabled = false;
                EnemyList[8].enabled = true;
                EnemyList[9].enabled = true;
            }
            if (Math.Round(time, 0) == 60)
            {
                EnemyList[8].enabled = false;
                EnemyList[9].enabled = false;
            }
        }
    }
}