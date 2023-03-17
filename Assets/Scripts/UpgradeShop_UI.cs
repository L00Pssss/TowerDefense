using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace TowerDefense
{
    public class UpgradeShop_UI : MonoBehaviour
    {
        [SerializeField] private int m_money;
        [SerializeField] private TextMeshProUGUI m_moneyText;
        [SerializeField] private BuyUpgrade_UI[] m_sales;
        [SerializeField] private TextMeshProUGUI m_manaText;
        [SerializeField] private BuyUpgrade_UI[] m_salesGold;
   //     [SerializeField] private BuyUpgrade_UI[] m_salesMana;

        private void Start()
        {
            foreach (var slot in m_salesGold)
            {
                Debug.Log($"{slot.name}   {m_salesGold.Length}");
                slot.Initialize();
                slot.transform.Find("Button").GetComponent<Button>().onClick.AddListener(UpdateMoney);
            }

            //foreach (var slot in m_salesMana)
            //{
            //    Debug.Log($"{slot.name}   {m_salesMana.Length}");
            //    slot.Initialize();
            //    slot.transform.Find("Button").GetComponent<Button>().onClick.AddListener(UpdateMoney);
            //}    


    //        UpdateMoney();
        }
        public void UpdateMoney()
        {
            m_money = MapCompletion.Instance.TotalScore;
            m_money -= Upgrades.GetTotalCost();
            m_moneyText.text = m_money.ToString();

            foreach (var slot in m_sales)
            //m_mana = MapCompletion.Instance.TotalMana;
            //m_mana -= Upgrades.GetTotalCost();
            //m_manaText.text = m_mana.ToString();

            foreach (var slot in m_salesGold)
            {
                slot.CheckCost(m_money);
            }

            //foreach (var slot in m_salesMana)
            //{
            //    slot.CheckCost(m_money);
            //}

        }
    }
}