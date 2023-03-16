using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TowerDefense
{
    public class UpgradeShop_UI : MonoBehaviour
    {
        [SerializeField] private int m_money;
        [SerializeField] private int m_mana;
        [SerializeField] private TextMeshProUGUI m_moneyText;
        [SerializeField] private TextMeshProUGUI m_manaText;
        [SerializeField] private BuyUpgrade_UI[] m_sales;
        private void Start()
        {
            foreach (var slot in m_sales)
            {
                slot.Initialize();
                slot.transform.Find("Button").GetComponent<Button>().onClick
                    .AddListener(UpdateMoney);
            }

            UpdateMoney();
        }
        public void UpdateMoney()
        {
            m_money = MapCompletion.Instance.TotalScore;    
            m_money -= Upgrades.GetTotalCost();
            m_moneyText.text = m_money.ToString();

            m_mana = MapCompletion.Instance.TotalMana;
            m_mana -= Upgrades.GetTotalCost();
            m_manaText.text = m_mana.ToString();

            foreach (var slot in m_sales)
            {
                slot.CheckCost(m_money);
                slot.CheckCost(m_mana);
            }
        }
    }
}