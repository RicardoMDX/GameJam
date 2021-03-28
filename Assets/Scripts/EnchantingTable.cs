using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnchantingTable : MonoBehaviour
{

    AudioSource audS_Table;

    public int i_ItemsCollected=0, i_ItemsCorrect=0;
    public Canvas cnv_PuzzleCanvas;

    private bool bl_PlayerInRange=false;
    private Canvas cnv_InteractionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        audS_Table = GetComponent<AudioSource>();
        cnv_InteractionCanvas = GetComponentInChildren<Canvas>();
        cnv_InteractionCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && bl_PlayerInRange && i_ItemsCollected==3)
        {
            cnv_PuzzleCanvas.gameObject.SetActive(true);
        }

        if (i_ItemsCorrect == 3)
        {
            audS_Table.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
