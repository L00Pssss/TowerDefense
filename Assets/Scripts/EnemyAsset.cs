using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public sealed class EnemyAsset : ScriptableObject
    {
        [Header("Appearance")]
        public Color color = Color.white;
        public Vector2 sprtiteScale = new Vector2 (3,3);
        public RuntimeAnimatorController animations;

        [Header("Game parameters")]
        public float moveSpeed = 1f;
        public int hp = 1;
        public int score = 1;
        public float radius = 0.19f;
    }
}