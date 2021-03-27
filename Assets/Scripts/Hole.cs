using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    private float f_Time, f_Timer = 2f;
    private bool b_Stepped=false;
    private GameObject go_Player;

    PlayerMovement scr_Player;
    AudioSource audS_Hole;

    // Start is called before the first frame update
    void Start()
    {
        scr_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audS_Hole = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= f_Time + f_Timer && b_Stepped)
        {
            scr_Player.SendMessage("Die");
        }
        if (b_Stepped)
        {
            go_Player.gameObject.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
            go_Player.gameObject.transform.Rotate(0, 0, 5f, Space.Self);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            audS_Hole.Play();
            go_Player = collision.gameObject;
            collision.GetComponentInChildren<Camera>().gameObject.transform.parent = null;
            f_Time = Time.time;
            scr_Player.SendMessage("Stop");
            b_Stepped = true;
        }
    }
}
