using UnityEngine;

namespace TowerDefense
{
    public class LevelDisplayController : MonoBehaviour
    {
        [SerializeField] private MapLevel[] levels;
        [SerializeField] private BranchLevel[] m_branchLevls;
        void Start()
        {
            var drawLevel = 0;
            var score = 1;
            while (score != 0 && drawLevel < levels.Length)
            {
                score = levels[drawLevel].Initialise();
                drawLevel += 1;
            }

            for (int i = drawLevel; i < levels.Length; i++)
            {
                levels[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < m_branchLevls.Length; i++)
            {   
                m_branchLevls[i].TryActuvate();
            }
        }
    }
}