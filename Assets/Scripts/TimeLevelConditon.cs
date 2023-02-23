using UnityEngine;

namespace TowerDefense
{
    public class TimeLevelConditon : MonoBehaviour, ILevelCondition
    {
        [SerializeField] private float m_timeLimit = 4f;

        public float TimeLimit => m_timeLimit;

        private void Start()
        {
            m_timeLimit += Time.time;
        }
        public bool IsCompleted => Time.time > m_timeLimit;
    }
}