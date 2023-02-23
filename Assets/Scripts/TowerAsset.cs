using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu]
    public class TowerAsset : ScriptableObject
    {
        public int goldCost = 15;
        public Sprite sprite;
        public Sprite towerGUI;

        public bool AddAnimationHero;
        public GameObject PrefabAnimationHero;

        public TurretProperties turretProperties;
        public TurretMode Mode;

        public float RadiusDetection = 5;
    }
}