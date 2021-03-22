using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Image img_IconImage;

    private Sprite spr_Sprite;

    // Start is called before the first frame update
    void Start()
    {
        spr_Sprite = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            img_IconImage.sprite = spr_Sprite;
        }
    }
}
