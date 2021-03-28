using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;
    AudioSource audS_Player;

    float f_H, f_V, f_MoveLimiter = 0.7f;
    bool b_Walking=false;

    public float f_Speed = 20f;
    public int i_Health = 3;
    public Image[] img_Hearts;
    public Sprite spr_BlackHeart;
    public AudioClip audC_Hole, audC_PlayerWalking, audC_GameOver;
    public Canvas cnv_RespawnCanvas;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        audS_Player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        f_H = Input.GetAxis("Horizontal");
        f_V = Input.GetAxis("Vertical");
        if (i_Health <= 0)
        {
            Die();
        }
    }

    private void FixedUpdate()
    {
        if(f_H!=0 && f_V!=0)
        {
            f_H *= f_MoveLimiter;
            f_V *= f_MoveLimiter;
        }

        if (f_H != 0 || f_V != 0 && !b_Walking)
        {
            audS_Player.clip = audC_PlayerWalking;
            audS_Player.Play();
        }
        else
        {
            audS_Player.Stop();
        }
        m_Rigidbody.velocity = new Vector2(f_H * f_Speed, f_V * f_Speed);
    }

    public void Die()
    {
        audS_Player.PlayOneShot(audC_GameOver);
        cnv_RespawnCanvas.gameObject.SetActive(true);
    }

    public void Stop()
    {
        m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void TakeDamage()
    {
        if (i_Health > 0)
        {
            img_Hearts[i_Health - 1].sprite = spr_BlackHeart;
            i_Health--;
        }
    }

    public void Respawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
