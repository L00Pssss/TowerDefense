using UnityEngine;

namespace TowerDefense
{
    public class Path : MonoBehaviour
    {
        [SerializeField] private AIPointPatrol[] points;
        public int Length { get => points.Length;  }

        public AIPointPatrol this[int i] { get => points[i]; }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            foreach (var point in points)
            {
                Gizmos.DrawSphere(point.transform.position, point.Radius);
            }

            for (int i = 0; i < points.Length; i++)
            {
              int increment = 1;
                if (points.Length == i + 1)
                {
                    increment = 0;
                }
              Gizmos.DrawLine(points[i].transform.position, points[i + increment].transform.position);
            }

        }
    }
}