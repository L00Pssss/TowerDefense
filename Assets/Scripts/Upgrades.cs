using System;
using UnityEngine;

namespace TowerDefense
{
    public class Upgrades : MonoSingleton<Upgrades>
    {
        public const string filename = "upgrades.dat";

        [Serializable]
        private class UpgradeSave
        {
            public UpgradeAsset_UI asset;
            public int level = 0;
        }
        [SerializeField] private UpgradeSave[] m_save;

        private new void Awake()
        {
            base.Awake();
            Saver<UpgradeSave[]>.TryLoad(filename, ref m_save);
        }
        public static void BuyUpgrade(UpgradeAsset_UI asset)
        {
            foreach (var upgrade in Instance.m_save)
            {
                if (upgrade.asset == asset)
                {
                    upgrade.level++;
                    Saver<UpgradeSave[]>.Save(filename, Instance.m_save);
                }
            } 
        }

        public static int GetUpgradeLevel(UpgradeAsset_UI asset)
        {
            foreach (var upgrade in Instance.m_save)
            {
                if (upgrade.asset == asset)
                {
                    return upgrade.level;
                }
            }
            return 0;
        }
    }
}