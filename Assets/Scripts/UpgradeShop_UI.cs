using UnityEngine;
using TMPro;

namespace TowerDefense
{
    public class UpgradeShop_UI : MonoBehaviour
    {

        [SerializeField] private int m_money;
        [SerializeField] private TextMeshProUGUI m_moneyText;
        [SerializeField] private BuyUpgrade_UI[] m_sales;
        private void Start()
        {
            m_money = MapCompletion.Instance.TotalScore;
            m_moneyText.text = m_money.ToString();

            foreach (var slot in m_sales)
            {
                slot.Initialize();
            }
        }
    }
}