using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{

    public GameObject[] go_Waypoint;
    public float f_Speed = 10f;
    public int i_NextWaypoint=1;

    PlayerMovement scr_Player;

    // Start is called before the first frame update
    void Start()
    {
        scr_Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void FixedUpdate()
    {
        transform.Rotate(0,0,360*Time.deltaTime,Space.Self);
        if (go_Waypoint.Length > 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, go_Waypoint[i_NextWaypoint].transform.position,f_Speed/50);
            if (transform.position == go_Waypoint[i_NextWaypoint].transform.position)
            {
                i_NextWaypoint++;
                if (i_NextWaypoint == go_Waypoint.Length)
                {
                    i_NextWaypoint = 0;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scr_Player.SendMessage("Die");
        }
    }
}
