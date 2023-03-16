using UnityEngine;
using System.Collections.Generic;
using UnityEditor.U2D.Path.GUIFramework;

namespace TowerDefense
{
    public class BuyControl : MonoBehaviour
    {
        [SerializeField] private TowerBuyControl m_TowerByPrefab;

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
        private void MoveToBuildSite(BuildSite buildSite)
        {
            if (buildSite)
            {
                var positon = Camera.main.WorldToScreenPoint(buildSite.transform.root.position); // root поскольку buildSite дочерный объект. 
                m_rectTransform.anchoredPosition = positon;
                gameObject.SetActive(true);
                m_ActiveControl = new List<TowerBuyControl>();
                foreach (var asset in buildSite.buildableTowers)
                {
                    if (asset.IsAvailable()) // значение в тавер асетах (условие)
                    {
                        var newContorl = (Instantiate(m_TowerByPrefab, transform));
                        m_ActiveControl.Add(newContorl);
                        newContorl.SetTowerAsset(asset);
                    }
                }
                if (m_ActiveControl.Count > 0)
                {
                    var angel = 360 / m_ActiveControl.Count;
                    for (int i = 0; i < m_ActiveControl.Count; i++)
                    {
                        var offset = Quaternion.AngleAxis(angel * i, Vector3.forward) * (Vector3.up * 80);
                        m_ActiveControl[i].transform.position += offset;
                    }
                }

                foreach (var tbc in GetComponentsInChildren<TowerBuyControl>())
                {
                    tbc.SetBuildStie(buildSite.transform.root);
                }
            }
            else
            {
                if (m_ActiveControl != null)
                {
                    foreach (var control in m_ActiveControl) Destroy(control.gameObject);
                    m_ActiveControl.Clear();
                }
                
                gameObject.SetActive(false);
            }

        }
    }

}