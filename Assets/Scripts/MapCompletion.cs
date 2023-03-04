using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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


        public static void SaveEpisodeResult(int levelScore)
        {
            if (Instance) // если есть сохаранение
                Instance.SaveResult(LevelSequenceController.Instance.CurrentEpisode, levelScore);
        }
        private void SaveResult(Episode currentEpisode, int levelScore)
        {
            foreach (var item in complitonData)
            {
                if (item.episode == currentEpisode)
                {
                    if (levelScore > item.score)
                    {
                        item.score = levelScore;
                        Saver<EpisodeScore[]>.Save(filename, complitonData);
                    }
                }

            }
        }

        [SerializeField] private EpisodeScore[] complitonData;
        private int totalScore;
        public int TotalScore => totalScore;
        private new void Awake()
        {
            base.Awake();
            Saver<EpisodeScore[]>.TryLoad(filename, ref complitonData);
            foreach (var episodeScore in complitonData)
            {
                totalScore += episodeScore.score;
            }
        }

        public int GetEpisodeScore(Episode m_episode)
        {
            foreach (var data in complitonData)
            {
               if (data.episode == m_episode)
                    return data.score;
            }
            return 0;
        }
    }
}