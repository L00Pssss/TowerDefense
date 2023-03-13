using UnityEngine;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private CircleArea m_startArea;
        [SerializeField] private AIPointPatrol[] m_points;
        public CircleArea StartArea => m_startArea;
        public int Length { get => m_points.Length;  }
        public AIPointPatrol this[int i] { get => m_points[i]; }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            foreach (var point in m_points)
            {
                Gizmos.DrawSphere(point.transform.position, point.Radius);
            }

            for (int i = 0; i < m_points.Length; i++)
            {
              int increment = 1;
                if (m_points.Length == i + 1)
                {
                    increment = 0;
                }
              Gizmos.DrawLine(m_points[i].transform.position, m_points[i + increment].transform.position);
            }
        }
    }
}