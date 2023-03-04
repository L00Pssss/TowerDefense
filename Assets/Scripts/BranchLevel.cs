using System;
using UnityEngine;
using TMPro;

namespace TowerDefense
{
    [RequireComponent(typeof(MapLevel))]
    public class BranchLevel : MonoBehaviour
    {
        [SerializeField] private MapLevel m_rootLevel;
        [SerializeField] private TextMeshProUGUI m_pointText;

        [SerializeField] private int m_NeedPoints = 3;

        public void TryActuvate()
        {
            gameObject.SetActive(m_rootLevel.IsComplete);
            if (m_NeedPoints > MapCompletion.Instance.TotalScore)
            {
                m_pointText.text = m_NeedPoints.ToString();
            }
            else
            {
                m_pointText.transform.parent.gameObject.SetActive(false);
                GetComponent<MapLevel>().Initialise();
            }         
        }
    }
}