using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowMovement : MonoBehaviour
{

    public float f_Speed = 10f;
    public AudioClip audC_ArrowShooting, audC_ArrowHitting;

    AudioSource audS_Source;
    Rigidbody2D m_Rigidbody;
    PlayerMovement scr_Player;

    // Start is called before the first frame update
    void Start()
    {
        audS_Source = GetComponent<AudioSource>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        scr_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        this.transform.parent = null;
        audS_Source.PlayOneShot(audC_ArrowShooting);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = transform.up * -f_Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            scr_Player.SendMessage("TakeDamage");
        }
        else if(collision.gameObject.tag=="Wall")
        {
            audS_Source.PlayOneShot(audC_ArrowHitting);
            Destroy(this.gameObject);
        }
    }
}
