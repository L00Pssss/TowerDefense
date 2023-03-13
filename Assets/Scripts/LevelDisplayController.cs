using UnityEngine;

namespace TowerDefense
{
    public class LevelDisplayController : MonoBehaviour
    {
        [SerializeField] private MapLevel[] m_levels;
        [SerializeField] private BranchLevel[] m_branchLevls;
        void Start()
        {
            var drawLevel = 0;
            var score = 1;
            while (score != 0 && drawLevel < m_levels.Length)
            {
                score = m_levels[drawLevel].Initialise();
                drawLevel += 1;
            }

            for (int i = drawLevel; i < m_levels.Length; i++)
            {
                m_levels[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < m_branchLevls.Length; i++)
            {   
                m_branchLevls[i].TryActuvate();
            }
        }
    }
}