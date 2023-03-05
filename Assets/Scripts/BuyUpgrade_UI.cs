using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class BuyUpgrade_UI : MonoBehaviour
    {
        [SerializeField] private UpgradeAsset_UI m_Asset;
        [SerializeField] private Image m_upgradeIcon;
        [SerializeField] private TextMeshProUGUI m_level, m_cost;
        [SerializeField] private Button m_buyButton;

        public void Initialize()
        {
            m_upgradeIcon.sprite = m_Asset.sprite;
            var savedLevel = Upgrades.GetUpgradeLevel(m_Asset);

            m_level.text += $" (MAX)";
            if (savedLevel >= m_Asset.costByLevel.Length)
            {
                m_buyButton.interactable = false;
                m_buyButton.transform.Find("Start_Image").gameObject.SetActive(false);
                m_buyButton.transform.Find("Text (TMP)").gameObject.SetActive(false);
                m_cost.text = "X";

            }
            else
            {
                m_level.text = $"Lvl: {savedLevel + 1}";
                m_cost.text = m_Asset.costByLevel[savedLevel].ToString();
            }
            
        }

        public void Buy()
        {
            Upgrades.BuyUpgrade(m_Asset);
            Initialize();
        }
    }
}