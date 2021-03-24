using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnchantingTable : MonoBehaviour
{

    public int i_ItemsCollected=0;

    private bool bl_PlayerInRange=false;
    private Canvas cnv_InteractionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        cnv_InteractionCanvas = GetComponentInChildren<Canvas>();
        cnv_InteractionCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && bl_PlayerInRange && i_ItemsCollected==3)
        {
            Debug.Log("Next level");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cnv_InteractionCanvas.gameObject.SetActive(true);
            bl_PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cnv_InteractionCanvas.gameObject.SetActive(false);
            bl_PlayerInRange = false;
        }
    }

    public void ItemCollected()
    {
        i_ItemsCollected++;
    }
}
