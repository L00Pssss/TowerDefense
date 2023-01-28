using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class TDPatrolController : AIController
    {
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
                Destroy(gameObject);
            }
        }
    }
}