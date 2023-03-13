using System;
using System.Collections.Generic;
using UnityEngine;


// Code for Test;
namespace TowerDefense
{
    public class SpawnTimeEnemy : MonoBehaviour
    {
        [SerializeField] List<EnemySpawner> EnemyList = new List<EnemySpawner>();

        [SerializeField] private int m_wave;

        [SerializeField] private float time;

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
    }
}