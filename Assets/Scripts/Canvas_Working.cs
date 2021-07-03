using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Canvas_Working : MonoBehaviour
{
    public GameObject Home_panel;
    public GameObject Shop_panel;
    [SerializeField]
    private GameObject load_bar;
    [SerializeField]
    private Slider load;

    public void Play() {
        load_bar.SetActive(true);
        Home_panel.SetActive(false);
        StartCoroutine(LoadAsynchronously("Official_Play"));
    }
    public void Practice()
    {
        load_bar.SetActive(true);
        Home_panel.SetActive(false);
        StartCoroutine(LoadAsynchronously("Official_Tutorial"));
    }
    public void Quit()
    {
        //do all respective modifications in values
        
        //Exit from application
        Application.Quit();
    }
    public void shop() {
        //close home panel
        Home_panel.SetActive(false);
        //open shop panel
        Shop_panel.SetActive(true);     
    }
    public void close_shop() {
        
        //close shop panel
        Shop_panel.SetActive(false);
        //open home panel
        Home_panel.SetActive(true);
    }

    IEnumerator LoadAsynchronously(string name) {

        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        while (!operation.isDone) {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            load.value = progress;
            yield return null;
        }
    }
}
