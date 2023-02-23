using UnityEngine;
using TMPro;

namespace TowerDefense
{
    public class MapLevel : MonoBehaviour
    {
        private Episode m_episode;
        [SerializeField] private TextMeshProUGUI m_text;
        public void LoadLevel()
        {
            if (m_episode)
                LevelSequenceController.Instance.StartEpisode(m_episode);
            else
                Debug.Log("Ёпизод не назначен");
        }

        public void SetLevelData(Episode episode, int score)
        {
            m_episode = episode;
            m_text.text = $"{score}/3";
        }

    }
} 