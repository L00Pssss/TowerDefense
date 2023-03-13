using UnityEngine;
using System.Collections.Generic;

namespace TowerDefense
{
    public class BuyControl : MonoBehaviour
    {
        [SerializeField] private TowerBuyControl m_TowerByPrefab;
        [SerializeField] private TowerAsset[] m_TowerAssets;
        [SerializeField] private UpgradeAsset_UI m_MageTowerUpgrade;
        private List<TowerBuyControl> m_ActiveControl;
        private RectTransform m_rectTransform;
        private void Awake()
        {
            m_rectTransform = GetComponent<RectTransform>();
            BuildSite.OnClickEvent += MoveToBuildSite;
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            BuildSite.OnClickEvent -= MoveToBuildSite;
        }
        private void MoveToBuildSite(Transform buildSite)
        {
            if (buildSite)
            {
                var positon = Camera.main.WorldToScreenPoint(buildSite.position);
                m_rectTransform.anchoredPosition = positon;
                gameObject.SetActive(true);
                m_ActiveControl = new List<TowerBuyControl>();
                for (int i = 0; i < m_TowerAssets.Length; i++)
                {
                    if (i != 1 || Upgrades.GetUpgradeLevel(m_MageTowerUpgrade) > 0)
                    {
                        var newContorl = (Instantiate(m_TowerByPrefab, transform));
                        m_ActiveControl.Add(newContorl);
                        newContorl.transform.position += Vector3.left * 100 * i;
                        newContorl.SetTowerAsset(m_TowerAssets[i]);
                    }
                }

            }
            else
            {
                foreach(var control in m_ActiveControl) Destroy(control.gameObject);
                gameObject.SetActive(false);
            }
            foreach (var tbc in GetComponentsInChildren<TowerBuyControl>())
            {
                tbc.SetBuildStie(buildSite);
            }
        }
    }
}