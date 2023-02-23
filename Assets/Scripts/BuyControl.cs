using UnityEngine;

namespace TowerDefense
{
    public class BuyControl : MonoBehaviour
    {
        [SerializeField] private RectTransform m_transform;
        private void Awake()
        {
            m_transform = GetComponent<RectTransform>();
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
                m_transform.anchoredPosition = positon;
                gameObject.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);
            }
            foreach (var tbc in GetComponentsInChildren<TowerBuyControl>())
            {
                tbc.SetBuildStie(buildSite);
            }
        }
    }
}