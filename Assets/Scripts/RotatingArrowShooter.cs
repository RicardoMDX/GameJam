using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingArrowShooter : MonoBehaviour
{

    public float f_Speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, -f_Speed * Time.deltaTime, Space.Self);
    }
}
