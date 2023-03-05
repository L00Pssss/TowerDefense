using UnityEngine;
using TMPro;
using System;

namespace TowerDefense
{
    public class UpgradeShop_UI : MonoBehaviour
    {
        [Serializable]
        private class UpgradeSlot
        {
            public BuyUpgrade_UI m_slot;
            public UpgradeAsset_UI m_upgrade;

            public void AssignUpgade()
            {
                m_slot.SetUpgrade(m_upgrade);
            }
        }

        [SerializeField] private int m_money;
        [SerializeField] private TextMeshProUGUI m_moneyText;
        [SerializeField] private UpgradeSlot[] m_sales;
        private void Start()
        {
            m_money = MapCompletion.Instance.TotalScore;
            m_moneyText.text = m_money.ToString();

            foreach (var slot in m_sales)
            {
                slot.AssignUpgade();
            }
        }
    }
}