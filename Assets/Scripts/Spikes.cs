using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private float f_Time, f_Timer = 2f;
    private bool b_Stepped=false;

    PlayerMovement scr_Player;

    // Start is called before the first frame update
    void Start()
    {
        scr_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= f_Time + f_Timer && b_Stepped)
        {
            scr_Player.SendMessage("Die");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            f_Time = Time.time;
            scr_Player.SendMessage("Stop");
            b_Stepped = true;
        }
    }
}
