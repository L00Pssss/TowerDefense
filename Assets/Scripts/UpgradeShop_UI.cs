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
        [SerializeField] private BuyUpgrade_UI[] m_salesGold;
        [SerializeField] private BuyUpgrade_UI[] m_salesMana;
        private void Start()
        {
            foreach (var slot in m_salesGold)
            {;
                slot.Initialize();
                slot.transform.Find("ButtonGold").GetComponent<Button>().onClick
                    .AddListener(UpdateMoney);
            }
            foreach (var slot in m_salesMana)
            {
                slot.Initialize();
                slot.transform.Find("ButtonMage").GetComponent<Button>().onClick
                    .AddListener(UpdateMana);
            }


            UpdateMoney();
            UpdateMana();
        }

        public void UpdateMoney()
        {
            m_money = MapCompletion.Instance.TotalScore;
            m_money -= Upgrades.GetTotalCost(TypeBuy.Gold);
            m_moneyText.text = m_money.ToString();

            foreach (var slot in m_salesGold)
            {
                slot.CheckCost(m_money, "m_money");
            }
        }  
        
        public void UpdateMana()
        {
            m_mana = MapCompletion.Instance.TotalMana;
            m_mana -= Upgrades.GetTotalCost(TypeBuy.Magic);
            m_manaText.text = m_mana.ToString();

            foreach (var slot in m_salesMana)
            {
                slot.CheckCost(m_mana, "m_mana");
            }
        }


    }
}