using UnityEngine;

namespace TowerDefense
{
    public class TDLeveLController : LevelController
    {
        private int levelScore = 3;

        private new void Start()
        {
            base.Start();
            TDPlayer.Instance.OnPlayerDead += () =>
            {
                StopLevelActivity();
                LevelResultController.Instance.Show(false);
            };


            m_ReferenceTime += Time.time;

            m_EventLevelCompleted.AddListener(() =>
            {
                StopLevelActivity();
                if (m_ReferenceTime <= Time.time)
                {
                    levelScore -= 1;
                }
                print(levelScore);
                MapCompletion.SaveEpisodeResult(levelScore);
            });

            TDPlayer.OnLifeUpdate += LifeSocreChange;

            void LifeSocreChange(int _)
            {
                levelScore -= 1;
                TDPlayer.OnLifeUpdate -= LifeSocreChange;
            }
        }
        private void StopLevelActivity()
        {
            foreach (var enemy in FindObjectsOfType<Enemy>())
            {
                enemy.GetComponent<SpaceShip>().enabled = false;
                enemy.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }

            void DisableAll<T>() where T : MonoBehaviour
            {
                foreach (var obj in FindObjectsOfType<T>())
                {
                    obj.enabled = false;
                }
            }

            DisableAll<Spawner>();
            DisableAll<Projectile>();
            DisableAll<Tower>();
            DisableAll<NextWaveGUI>();
        }
    }
}