using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D m_Rigidbody;

    float f_H, f_V, f_MoveLimiter = 0.7f;

    public float f_Speed = 20f;

    public Canvas cnv_RespawnCanvas;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        f_H = Input.GetAxis("Horizontal");
        f_V = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        if(f_H!=0 && f_V!=0)
        {
            f_H *= f_MoveLimiter;
            f_V *= f_MoveLimiter;
        }

        m_Rigidbody.velocity = new Vector2(f_H * f_Speed, f_V * f_Speed);
    }

    public void Die()
    {
        cnv_RespawnCanvas.gameObject.SetActive(true);
    }

    public void Stop()
    {
        m_Rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Respawn()
    {
        int i_CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(i_CurrentScene);
    }
}
