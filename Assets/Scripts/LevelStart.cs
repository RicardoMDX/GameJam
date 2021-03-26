using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{

    public GameObject go_Player;
    public Canvas cnv_Introduction;
    public float f_YLevel;

    private bool b_Stop = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!b_Stop)
        {
            go_Player.transform.Translate(Vector3.up * Time.deltaTime*10, Space.World);
        }

        if (go_Player.transform.position.y >=f_YLevel)
        {
            b_Stop = true;
            cnv_Introduction.gameObject.SetActive(true);
        }
    }

    public void CloseCanvas()
    {
        cnv_Introduction.gameObject.SetActive(false);
        Destroy(this);
    }
}
