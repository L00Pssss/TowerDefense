using UnityEngine.EventSystems;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace TowerDefense
{
    public class BuildSite : MonoBehaviour, IPointerDownHandler
    {
        public TowerAsset[] buildableTowers;
        public void SetBuildableTowers(TowerAsset[] towers)
        {
            if (towers == null || towers.Length == 0)
            {
                buildableTowers = towers;
            }
            else
            {
                Destroy(transform.parent.gameObject);
                
            }
        }

        public static event Action<BuildSite> OnClickEvent;
        public static void HideContorls()
        {
            OnClickEvent(null);
        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnClickEvent(this);
        }
    }
}