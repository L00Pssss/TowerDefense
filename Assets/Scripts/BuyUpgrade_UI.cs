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
        [SerializeField] private int m_costGold = 0;
        [SerializeField] private TextMeshProUGUI m_level, m_costText;
        [SerializeField] private Button m_buyButton;

        public void Initialize()
        {
            m_upgradeIcon.sprite = m_asset.sprite;
            var savedLevel = Upgrades.GetUpgradeLevel(m_asset);

            if (savedLevel >= m_asset.costByLevelGold.Length && m_asset.ManaOrGold == false)
            {
                m_level.text = $"Level:{savedLevel} (MAX)";
                m_buyButton.interactable = false;
                m_buyButton.transform.Find("Start_Image").gameObject.SetActive(false);
                m_buyButton.transform.Find("Text (TMP)").gameObject.SetActive(false);
                m_costText.text = "X";
                m_costGold = int.MaxValue;
            }
            if (savedLevel >= m_asset.costByLevelMana.Length && m_asset.ManaOrGold == true)
            {
                m_level.text = $"Level:{savedLevel} (MAX)";
                m_buyButton.interactable = false;
                m_buyButton.transform.Find("Start_Image").gameObject.SetActive(false);
                m_buyButton.transform.Find("Text (TMP)").gameObject.SetActive(false);
                m_costText.text = "X";
                m_costMana = int.MaxValue;
            }
            if (savedLevel < m_asset.costByLevelMana.Length || savedLevel < m_asset.costByLevelGold.Length)
            {             
                if (m_asset.ManaOrGold == false)
                {
                    m_level.text = $"Lvl: {savedLevel + 1}";
                    m_costGold = m_asset.costByLevelGold[savedLevel];
                    m_costText.text = m_costGold.ToString();
                }
                if (m_asset.ManaOrGold == true)
                {
                    m_level.text = $"Lvl: {savedLevel + 1}";
                    m_costMana = m_asset.costByLevelMana[savedLevel];
                    m_costText.text = m_costMana.ToString();
                }
            }
            
        }
        public void Buy()
        {
            Upgrades.BuyUpgrade(m_asset);
            Initialize();
        }
        public void CheckCost(int value, string name)
        {
            if (name == "m_money")
            {
                m_buyButton.interactable = value >= m_costGold;
            }
            if (name == "m_mana")
            {
                m_buyButton.interactable = value >= m_costMana;
            }
        }
    }
}