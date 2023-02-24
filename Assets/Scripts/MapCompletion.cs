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

        private new void Awake()
        {
            base.Awake();
            Saver<EpisodeScore[]>.TryLoad(filename, ref complitonData);
        }

        public bool TryIndex(int id, out Episode episode, out int score)
        {
            if (id >= 0 && id < complitonData.Length)
            {
                episode = complitonData[id].episode;
                score = complitonData[id].score;
                return true;
            }
            episode = null;
            score = 0;
            return false;
        }
 
   
    }
}