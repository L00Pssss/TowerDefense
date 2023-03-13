using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class TDPatrolController : AIController
    {
        [SerializeField] private UnityEvent OnEndPath;

        private Path m_path;
        private int m_PathIndex;
        

        public void SetPath(Path newPath)
        {
            m_path = newPath;
            m_PathIndex = 0;
            SetPatrolBehaviour(m_path[m_PathIndex]);
        }

        protected override void GetNewPoint()
        {
            if (m_path.Length > ++m_PathIndex)
            {
                SetPatrolBehaviour(m_path[m_PathIndex]);
            }
            else
            {
                OnEndPath.Invoke();
                Destroy(gameObject);
            }
        }
    }
}