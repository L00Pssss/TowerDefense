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

        [SerializeField] private UpgradeAsset_UI requiredUpgrade;
        [SerializeField] private int requiredUpgradeLevel;
        public bool IsAvailable() => !requiredUpgrade ||
            requiredUpgradeLevel <= Upgrades.GetUpgradeLevel(requiredUpgrade); //if (requiredUpgrade)//  return requiredUpgradeLevel <= Upgrades.GetUpgradeLevel(requiredUpgrade); //else return true;


        public TowerAsset[] m_UpgradesTo;
    }
}