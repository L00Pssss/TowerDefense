using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TowerDefense
{
    public class TowerBuyControl : MonoBehaviour
    {
        [SerializeField] private TowerAsset m_TowerAsset;

        [SerializeField] private TextMeshProUGUI m_text;

        [SerializeField] private Button m_button;

        [SerializeField] private Transform buildSite;

        private void Start()
        {
            TDPlayer.GoldUpdateSubscribe(GoldSatatusCheck);
            m_text.text = m_TowerAsset.goldCost.ToString();
            m_button.GetComponent<Image>().sprite = m_TowerAsset.towerGUI;
        }

        public void SetBuildStie(Transform value)
        {
            buildSite = value;
        }
        public void SetTowerAsset(TowerAsset asset)
        {
            m_TowerAsset = asset;
        }
       
        private void GoldSatatusCheck(int gold)
        {
            if (gold >= m_TowerAsset.goldCost != m_button.interactable)
            {
                m_button.interactable = !m_button.interactable;

                m_text.color = m_button.interactable ? Color.white : Color.red; //
            }
        }
        private void OnDestroy()
        {
            TDPlayer.Instance.GoldUpdateUnSubscribe(GoldSatatusCheck);
            // TDPlayer.Instance.LifeUpdateUnSubscribe(Gol
        }
        // Достаточное колическтво денег - предусловие этой процедуры
        public void Buy()
        {
            TDPlayer.Instance.TryBuild(m_TowerAsset, buildSite);
            BuildSite.HideContorls();
        }


    }
}