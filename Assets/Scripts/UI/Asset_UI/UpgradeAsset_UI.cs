using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public sealed class UpgradeAsset_UI : ScriptableObject
    {
        [Header("Visual Icon")]
        public Sprite sprite;

        public int[] costByLevel = { 3 };

        //[Header("Appearance")]
        //public Color color = Color.white;
        //public Vector2 sprtiteScale = new Vector2 (3,3);
        //public RuntimeAnimatorController animations;
        //public bool FlipY = false;

        //[Header("Game parameters")]
        //public float moveSpeed = 1f;
        //public int hp = 1;
        //public int score = 1;
        //[Header("Collider")]
        //public float radius = 0.19f;
        //public Vector2 offset = new Vector2(0,0);

        //[Header("Invoke")]
        //public int damage = 1;
        //public int gold = 1;
    }
}