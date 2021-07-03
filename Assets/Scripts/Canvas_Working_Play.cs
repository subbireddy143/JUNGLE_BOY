using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class Canvas_Working_Play : MonoBehaviour
{
    public GameObject Resume_Panel;
    public float Time_Scale;

    private string adid = "3539044"; 

    private string videoad = "video";
    void Start()
    {
        Time_Scale = 1f;

    }
    public void pause() {
        //open resume panel
        Resume_Panel.SetActive(true);
        //time Scale to 0
        Time.timeScale = 0f;
        if (Advertisement.IsReady(videoad))
        {
            Advertisement.Show(videoad);
        }
    }
    public void resume() {
        //close resume panel
        Resume_Panel.SetActive(false);
        //set time scale to previous
        Time.timeScale = Time_Scale;
    }
    public void restart() {
        //Set the initial situation
        SceneManager.LoadScene("Official_Play");
        //time scale to 1
        Time.timeScale = 1f;
    }
    public void home() {
        //move to home
        if (Advertisement.IsReady(videoad))
        {
            Advertisement.Show(videoad);
        }
        Time_Scale = 1f;
        SceneManager.LoadScene("Official_Home");
    }
    
    
}
