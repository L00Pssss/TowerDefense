using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class BuyUpgrade_UI : MonoBehaviour
    {
        [SerializeField] private UpgradeAsset_UI m_asset;
        [SerializeField] private Image m_upgradeIcon;
        [SerializeField] private int m_costNumber = 0;
        [SerializeField] private TextMeshProUGUI m_level, m_costText;
        [SerializeField] private Button m_buyButton;

        public void Initialize()
        {
            m_upgradeIcon.sprite = m_asset.sprite;
            var savedLevel = Upgrades.GetUpgradeLevel(m_asset);
     
            if (savedLevel >= m_asset.costByLevel.Length)
            {
                m_level.text = $"Level:{savedLevel} (MAX)";
                m_buyButton.interactable = false;
                m_buyButton.transform.Find("Start_Image").gameObject.SetActive(false);
                m_buyButton.transform.Find("Text (TMP)").gameObject.SetActive(false);
                m_costText.text = "X";
                m_costNumber = int.MaxValue;
            }
            else
            {
                m_level.text = $"Lvl: {savedLevel + 1}";
                m_costNumber = m_asset.costByLevel[savedLevel];
                m_costText.text = m_costNumber.ToString();
            }
            
        }
        public void Buy()
        {
            Upgrades.BuyUpgrade(m_asset);
            Initialize();
        }
        public void CheckCost(int m_money)
        {
            m_buyButton.interactable = m_money >= m_costNumber;
        }
    }
}