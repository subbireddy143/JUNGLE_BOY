using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWorking : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Charecter;

    public GameObject Main_Charecter;
    
    //Freeze components
    [SerializeField]
    private Transform Freeze;

    //Fertilizer components
    //public GameObject Ferti_Manager;
    //int ferti_count;
    ///float percent;
    //public Image Ferti_image;

    // Start is called before the first frame update
    void Start()
    {
        //Charecter Switching
        foreach (GameObject i in Charecter)
        {
            i.SetActive(false);
        }
        Set_Char(PlayerPrefs.GetString("MainPlayer", "none"));

        Freeze_Working();
        //Gem_Pack();is done in other script

        //Ferti_working_initials
        /*ferti_count = PlayerPrefs.GetInt("Fertilizer_Time", 0);
        Ferti_image.fillAmount = 0f;
        Ferti_Manager.SetActive(false);
        if (ferti_count>0)
        {
            Ferti_Manager.SetActive(true);
            Ferti_image.fillAmount = 1f;
            InvokeRepeating("Ferti_Working",1f,1f);
        }*/
    }

    private void Update()
    {
        
    }
    private void Set_Char(string charecter)
    {
        Main_Charecter.SetActive(false);
        switch(charecter)
        {
            case "Bear":
                Charecter[0].SetActive(true);
                break;
            case "Cheetah":
                Charecter[1].SetActive(true);
                break;
            case "Leapord":
                Charecter[2].SetActive(true);
                break;
            case "Tiger":
                Charecter[3].SetActive(true);
                break;
            default:
                Main_Charecter.SetActive(true);
                break;
        }
    }

    private void Freeze_Working()
    {
        if (PlayerPrefs.GetInt("Freeze", 0) == 1)
        {
            Vector3 pos = Freeze.position;
            PlayerPrefs.SetInt("Freeze", 0);
            pos.x = 30f;
            Freeze.position = pos;
        }
    }
    /*
    private void Ferti_Working()
    {
        if (PlayerPrefs.GetInt("Fertilizer_Time", 0) > 0)
        {
            PlayerPrefs.SetInt("Fertilizer_Time", (PlayerPrefs.GetInt("Fertilizer_Time", 0) - 1));
            if (ferti_count != 0)
                Ferti_image.fillAmount = (PlayerPrefs.GetInt("Fertilizer_Time", 0)) / ferti_count;
        }
        else
        {
            PlayerPrefs.SetInt("Fertilizer_Time", 0);
            Ferti_Manager.SetActive(false);
            Ferti_image.fillAmount = 0f;
            CancelInvoke("Ferti_Working");
        }
    }
    */
}

