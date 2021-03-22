using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ArrowMovement : MonoBehaviour
{

    public float f_Speed = 10f;

    Rigidbody2D m_Rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        m_Rigidbody.velocity = transform.up * f_Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            int i_CurrentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(i_CurrentScene);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
