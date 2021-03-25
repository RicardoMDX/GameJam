using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowMovement : MonoBehaviour
{

    public float f_Speed = 10f;

    Rigidbody2D m_Rigidbody;
    PlayerMovement scr_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        scr_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        this.transform.parent = null;
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
            scr_Player.SendMessage("Die");
        }
        else if(collision.gameObject.tag=="Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
