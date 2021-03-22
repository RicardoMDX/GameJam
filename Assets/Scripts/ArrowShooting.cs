using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooting : MonoBehaviour
{

    public GameObject go_Arrow, go_ArrowSpawn;
    public float f_FireRate;

    float f_LastShot;
    bool b_CanShoot=true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= f_LastShot + (1 / f_FireRate))
        {
            b_CanShoot = true;
        }
    }

    private void FixedUpdate()
    {
        if (b_CanShoot)
        {
            Instantiate(go_Arrow, go_ArrowSpawn.transform);
            f_LastShot = Time.time;
            b_CanShoot = false;
        }
    }
}
