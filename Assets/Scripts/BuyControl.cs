using UnityEngine;

public class BuyControl : MonoBehaviour
{
    private RectTransform transform;
    private void Awake()
    {
        transform = GetComponent<RectTransform>();
        BuildSite.OnClickEvent += MoveToTransform;
        gameObject.SetActive(false);
    }

    private void MoveToTransform(Transform target)
    {
        if (target)
        {
            var positon = Camera.main.WorldToScreenPoint(target.position);
            print(positon);
            transform.anchoredPosition = positon;
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
