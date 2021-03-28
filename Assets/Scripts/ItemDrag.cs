using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    AudioSource audS_Item;

    public GameObject go_Spot;
    public EnchantingTable scr_EnchantingTable;

    private RectTransform rectTransform;

    private void Awake()
    {
        audS_Item = GetComponent<AudioSource>();
        rectTransform = GetComponent<RectTransform>();
        scr_EnchantingTable = GameObject.FindGameObjectWithTag("EnchantingTable").GetComponent<EnchantingTable>();
    }

    public void Update()
    {
        float distance = Vector3.Distance(go_Spot.transform.position,this.transform.position);
        if(distance<=50)
        {
            audS_Item.Play();
            this.transform.SetPositionAndRotation(go_Spot.transform.position, go_Spot.transform.rotation);
            this.GetComponent<ItemDrag>().enabled = false;
            scr_EnchantingTable.i_ItemsCorrect++;
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
