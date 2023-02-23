using UnityEngine;

namespace TowerDefense
{
    public class LevelDisplayController : MonoBehaviour
    {
        [SerializeField] private MapLevel[] levels;
        void Start()
        {
            var drawLevel = 0;
            var score = 1;
            while (score != 0 &&
                drawLevel < levels.Length &&
                MapCompletion.Instance.TryIndex(drawLevel, out var episdoe, out  score))
            {
                levels[drawLevel].SetLevelData(episdoe, score);
                drawLevel += 1;
            }

            for (int i = drawLevel; i < levels.Length; i++)
            {
                levels[i].gameObject.SetActive(false);
            }
        }
    }
}