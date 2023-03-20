using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public sealed class UpgradeAsset_UI : ScriptableObject
    {
        [Header("Visual Icon")]
        public Sprite sprite;

        public int[] costByLevelGold = { 3 };
        public int[] costByLevelMana = { 3 };
        public bool ManaOrGold;
    }
}