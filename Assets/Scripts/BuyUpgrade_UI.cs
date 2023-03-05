using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TowerDefense
{
    public class BuyUpgrade_UI : MonoBehaviour
    {
        [SerializeField] private Image m_upgradeIcon;
        [SerializeField] private TextMeshProUGUI m_level, m_cost;
        [SerializeField] private Button m_buyButton;

        public void SetUpgrade(UpgradeAsset_UI asset, int level = 1)
        {
            m_upgradeIcon.sprite = asset.sprite;
            m_level.text = $"Lvl: {level}";
            m_cost.text = asset.costByLevel[level -1].ToString();
        }
    }
}