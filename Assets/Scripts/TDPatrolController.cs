using UnityEngine;
using UnityEngine.Events;

namespace TowerDefense
{
    public class TDPatrolController : AIController
    {
        [SerializeField] private UnityEvent OnEndPath;

        private Path m_path;
        private int PathIndex;
        

        public void SetPath(Path newPath)
        {
            m_path = newPath;
            PathIndex = 0;
            SetPatrolBehaviour(m_path[PathIndex]);
        }

        protected override void GetNewPoint()
        {
            if (m_path.Length > ++PathIndex)
            {
                SetPatrolBehaviour(m_path[PathIndex]);
            }
            else
            {
                OnEndPath.Invoke();
                Destroy(gameObject);
            }
        }
    }
}