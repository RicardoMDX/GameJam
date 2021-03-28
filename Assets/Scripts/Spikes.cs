using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    public AudioClip audC_Spikes;
    public Sprite spr_Spikes, spr_DeadPlayer;

    private float f_Time, f_Timer = 2f;
    private bool b_Stepped=false;

    AudioSource audS_Spikes;
    PlayerMovement scr_Player;

    // Start is called before the first frame update
    void Start()
    {
        scr_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audS_Spikes = GetComponent<AudioSource>();
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
            GetComponent<SpriteRenderer>().sprite = spr_Spikes;
            audS_Spikes.PlayOneShot(audC_Spikes);
            collision.gameObject.GetComponent<SpriteRenderer>().sprite = spr_DeadPlayer;
            f_Time = Time.time;
            scr_Player.SendMessage("Stop");
            b_Stepped = true;
        }
    }
}
