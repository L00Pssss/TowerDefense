using UnityEngine.EventSystems;
using UnityEngine;
using System;

namespace TowerDefense
{
    public class BuildSite : MonoBehaviour, IPointerDownHandler
    {
        public static event Action<Transform> OnClickEvent;
        public static void HideContorls()
        {
            OnClickEvent(null);
        }
        public virtual void OnPointerDown(PointerEventData eventData)
        {
            OnClickEvent(transform.root);
        }
    }
}