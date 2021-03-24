using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    public GameObject go_Spot;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void Update()
    {
        float distance = Vector3.Distance(go_Spot.transform.position,this.transform.position);
        Debug.Log(distance);
        if(distance<=50)
        {
            this.transform.SetPositionAndRotation(go_Spot.transform.position, go_Spot.transform.rotation);
            this.GetComponent<ItemDrag>().enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventDate)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }
}
