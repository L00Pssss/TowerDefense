using System;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class BuyUpgrade_UI : MonoBehaviour
    {
        [SerializeField] private UpgradeAsset_UI m_asset;
        [SerializeField] private Image m_upgradeIcon;
        [SerializeField] private int m_costMana = 0;
        [SerializeField] private int m_costMoney = 0;
        [SerializeField] private TextMeshProUGUI m_level, m_costText;
        [SerializeField] private Button m_buyButton;


        public virtual void Initialize()
        {
            m_upgradeIcon.sprite = m_asset.sprite;
            

            //var savedLevelMana = Upgrades.GetUpgradeLevel(m_asset);
            //string nameUpgradeMana = "costByManaMana";

            string nameUpgradeGold = "costByLevel";
            int savedLevel = Upgrades.GetUpgradeLevel(m_asset);



            if (savedLevel >= m_asset.costByLevelGold.Length)
            {
                UseGoldOrMana(savedLevel/*, nameUpgradeGold*/);
            }

            else
            {
                m_level.text = $"Lvl: {savedLevel + 1}";
                m_costMoney = m_asset.costByLevelGold[savedLevel];
                m_costText.text = m_costMoney.ToString();
            }

            //if (savedLevelMana >= m_asset.costByManaMana.Length)
            //{
            //    UseGoldOrMana(savedLevelMana, nameUpgradeMana);
            //}


            //if (savedLevelMana < m_asset.costByManaMana.Length)
            //{
            //    m_level.text = $"Lvl: {savedLevelMana + 1}";
            //    m_costMana = m_asset.costByLevelGold[savedLevelMana];
            //    m_costText.text = m_costMana.ToString();
            //}
            
        }

        public void Buy()
        {
            Upgrades.BuyUpgrade(m_asset);
            Initialize();
        }
        public void CheckCost(int money)
        {
            m_buyButton.interactable = money >= m_costMoney;
        //    m_buyButton.interactable = money >= m_costMana;
        }


        private void UseGoldOrMana(int currentLevel/*, string nameUpgrade*/)
        {
            //if (nameUpgrade == "costByLevel")
            //{
                m_level.text = $"Level:{currentLevel} (MAX)";
                m_buyButton.interactable = false;
                m_buyButton.transform.Find("Start_Image").gameObject.SetActive(false);
                m_buyButton.transform.Find("Text (TMP)").gameObject.SetActive(false);
                m_costText.text = "X";
                m_costMoney = int.MaxValue;
            //}
            //if (nameUpgrade == "costByManaMana")
            //{
            //    m_level.text = $"Level:{currentLevel} (MAX)";
            //    m_buyButton.interactable = false;
            //    m_buyButton.transform.Find("Start_Image").gameObject.SetActive(false);
            //    m_buyButton.transform.Find("Text (TMP)").gameObject.SetActive(false);
            //    m_costText.text = "X";
            //    m_costMana = int.MaxValue;
            //}
        }
        
    }
}