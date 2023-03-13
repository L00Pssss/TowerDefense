using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class MapLevel : MonoBehaviour
    {
        [SerializeField] private Episode m_episode;
        [SerializeField] private RectTransform m_resultPanel;
        [SerializeField] private Image[] m_resultImages;

        public bool IsComplete { get { return gameObject.activeSelf && 
                    m_resultPanel.gameObject.activeSelf; } }

        public void LoadLevel()
        {
            if (m_episode)
                LevelSequenceController.Instance.StartEpisode(m_episode);
            else
                Debug.Log("Ёпизод не назначен");
        }
        public int Initialise()
        {
            var score = MapCompletion.Instance.GetEpisodeScore(m_episode);

            m_resultPanel.gameObject.SetActive(score > 0);

            for (int i = 0; i < score; i++)
            {
                m_resultImages[i].color = Color.white;
            }
            return score;
        }
    }
} 