using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{

    public Canvas cnv_Rules, cnv_Credits;
    public AudioSource audS_Buttons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        audS_Buttons.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ShowRules()
    {
        audS_Buttons.Play();
        cnv_Rules.gameObject.SetActive(true);
    }

    public void CloseRules()
    {
        audS_Buttons.Play();
        cnv_Rules.gameObject.SetActive(false);
    }
    public void ShowCredits()
    {
        audS_Buttons.Play();
        cnv_Credits.gameObject.SetActive(true);
    }

    public void CloseCredits()
    {
        audS_Buttons.Play();
        cnv_Credits.gameObject.SetActive(false);
    }
}
