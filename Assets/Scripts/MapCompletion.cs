using System;
using UnityEngine;

namespace TowerDefense
{
    public class MapCompletion : MonoSingleton<MapCompletion>
    {
        public const string filename = "completion.dat";

        [Serializable]
        private class EpisodeScore
        {
            public Episode episode;
            public int score;
        }
        private new void Awake()
        {
            base.Awake();
            Saver<EpisodeScore[]>.TryLoad(filename, ref m_complitonData);
            foreach (var episodeScore in m_complitonData)
            {
                TotalScore += episodeScore.score;
                TotalMana  += episodeScore.score;
            }
        }

        public int TotalScore { private set; get; }
        public int TotalMana { private set; get; }

        [SerializeField] private EpisodeScore[] m_complitonData;

        public static void SaveEpisodeResult(int levelScore)
        {
            if (Instance) // если есть сохаранение
            {
                foreach (var item in Instance.m_complitonData)
                {
                    if (item.episode == LevelSequenceController.Instance.CurrentEpisode)
                    {
                        if (levelScore > item.score)
                        {
                            Instance.TotalScore += levelScore - item.score;
                            Instance.TotalMana += levelScore - item.score;
                            item.score = levelScore;
                            Saver<EpisodeScore[]>.Save(filename, Instance.m_complitonData);
                        }
                    }
                }
            }
            else
            {
                Debug.Log($"Episode complete with score {levelScore}");
            }
        }
        public int GetEpisodeScore(Episode m_episode)
        {
            foreach (var data in m_complitonData)
            {
               if (data.episode == m_episode)
                    return data.score;
            }
            return 0;
        }
    }
}