using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public sealed class UpgradeAsset_UI : ScriptableObject
    {
        [Header("Visual Icon")]
        public Sprite sprite;

        public int[] costByLevel = { 3 };
    }
}