using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    AudioSource audS_Item;

    public Image img_IconImage;
    public EnchantingTable scr_EnchantingTable;

    private Sprite spr_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        spr_Sprite = GetComponent<SpriteRenderer>().sprite;
        scr_EnchantingTable = GameObject.FindGameObjectWithTag("EnchantingTable").GetComponent<EnchantingTable>();
        audS_Item = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            audS_Item.Play();
            Destroy(this.gameObject);
            img_IconImage.sprite = spr_Sprite;
            scr_EnchantingTable.i_ItemsCollected++;
        }
    }
}
