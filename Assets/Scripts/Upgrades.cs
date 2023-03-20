using System;
using UnityEngine;

namespace TowerDefense
{
    public enum TypeBuy
    { 
        Gold, Magic 
    }
    public class Upgrades : MonoSingleton<Upgrades>
    {

        public const string filename = "upgrades.dat";

        [Serializable]
        private class UpgradeSave
        {
            public UpgradeAsset_UI asset;
            public int level = 0;
            public TypeBuy m_typeBuy;
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
            int result = 0;
            foreach (var upgrade in Instance.m_save)
            {
                if (upgrade.asset == asset)
                {
                    return upgrade.level;
                }
            }
            return result;
        }

        public static int GetTotalCost(TypeBuy typeBuy)
        {
            int result = 0;
            foreach (var upgrade in Instance.m_save)
            {
                if (TypeBuy.Gold == typeBuy)
                {
                    for (int i = 0; i < upgrade.level && i < upgrade.asset.costByLevelGold.Length; i++)
                    {
                        result += upgrade.asset.costByLevelGold[i];
                    }
                }

                if (TypeBuy.Magic == typeBuy)
                {
                    for (int i = 0; i < upgrade.level && i < upgrade.asset.costByLevelMana.Length; i++)
                    {
                        result += upgrade.asset.costByLevelMana[i];
                    }
                }
            }
            return result;
        }
    }
}