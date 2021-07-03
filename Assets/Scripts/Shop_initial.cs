using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_initial : MonoBehaviour
{
    [SerializeField]
    private GameObject less_coin;

    [SerializeField]
    private Text coin, gem;

    public bool coin_IsSpent = false,gem_IsSpent = false;

    //Charecter Switching initials
    [SerializeField]
    private GameObject[] Use_Buttons, Unlock_Buttons;

    [SerializeField]
    private Text[] using_text;


    //Coin items initials

    private void Start()
    {
        //PlayerPrefs.SetInt("Coins", 5000);
        coin.text = PlayerPrefs.GetInt("Coins", 100).ToString();
        gem.text = PlayerPrefs.GetInt("Gems", 20).ToString();

        //Setting charecter to default state
        PlayerPrefs.SetString("MainPlayer", "none");
        Debug.Log(PlayerPrefs.GetString("MainPlayer", "none"));
        Set_Initial();

        //Fertilizer's Initial
        PlayerPrefs.SetInt("Fertilizer_Time",0);

        //Energy initials
        PlayerPrefs.SetInt("Energy_percent",0);

        //Gem initials
        PlayerPrefs.SetInt("Gem_pack",0);

        //Freeze initials

        PlayerPrefs.SetInt("Freeze", 0);
    }

    public void spend_coins(int Coins) {
        //Debug.Log(IsSpent);
        if (PlayerPrefs.GetInt("Coins") >= Coins) {
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") - Coins);
            coin.text = PlayerPrefs.GetInt("Coins", 0).ToString();
            coin_IsSpent = true;
            //Debug.Log(IsSpent);
        }   

        else
            Instantiate(less_coin,transform.position,transform.rotation);
    }

    public void spend_Gems(int Gems) {
        //Debug.Log(IsSpent);
        if (PlayerPrefs.GetInt("Gems") >= Gems) {
            PlayerPrefs.SetInt("Gems", PlayerPrefs.GetInt("Gems") - Gems);
            gem.text = PlayerPrefs.GetInt("Gems", 0).ToString();
            gem_IsSpent = true;
            //Debug.Log(IsSpent);
        }   

        else
            Instantiate(less_coin,transform.position,transform.rotation);
    }


    public void self_inactive(GameObject Self) {
        if (coin_IsSpent == true) {
            //Debug.Log(IsSpent);
            Self.SetActive(false);
            //coin_IsSpent = false;
            //Debug.Log(IsSpent);
        }
    }

    public void Unlock_Charecter(string charecter_Name) {
        if (gem_IsSpent == true) {
            gem_IsSpent = false;
            switch (charecter_Name)
            {
                case "bear":
                    //Debug.Log("Unlock bear");
                    PlayerPrefs.SetString("Bear", "Unlocked");
                    Use_Buttons[0].SetActive(true);
                    Unlock_Buttons[0].SetActive(false);
                    break;
                case "cheetah":
                    //Debug.Log("Unlock cheetah");
                    PlayerPrefs.SetString("Cheetah", "Unlocked");
                    Use_Buttons[1].SetActive(true);
                    Unlock_Buttons[1].SetActive(false);
                    break;
                case "leopard":
                    //Debug.Log("Unlock leopard");
                    PlayerPrefs.SetString("Leopard", "Unlocked");
                    Use_Buttons[2].SetActive(true);
                    Unlock_Buttons[2].SetActive(false);
                    break;
                case "tiger":
                    //Debug.Log("Unlock tiger");
                    PlayerPrefs.SetString("Tiger", "Unlocked");
                    Use_Buttons[3].SetActive(true);
                    Unlock_Buttons[3].SetActive(false);
                    break;
            }
        }
        
    }

    //Initials for charecter switching
    private void Set_UseButtons(bool state)
    {
        foreach (GameObject i in Use_Buttons) {
            i.SetActive(state);
        }   
    }

    private void Set_UnlockButtons(bool state)
    {
        foreach (GameObject i in Unlock_Buttons)
        {
            i.SetActive(state);
        }

    }

    private void Set_Initial()
    {
        Set_UseButtons(false);
        Set_UnlockButtons(true);

        if (PlayerPrefs.GetString("Bear", "none") == "Unlocked")
        {
            Unlock_Buttons[0].SetActive(false);
            Use_Buttons[0].SetActive(true);
        }
        if (PlayerPrefs.GetString("Cheetah", "none") == "Unlocked")
        {
            Unlock_Buttons[1].SetActive(false);
            Use_Buttons[1].SetActive(true);
        }
        if (PlayerPrefs.GetString("Leopard", "none") == "Unlocked")
        {
            Unlock_Buttons[2].SetActive(false);
            Use_Buttons[2].SetActive(true);
        }
        if (PlayerPrefs.GetString("Tiger", "none") == "Unlocked")
        {
            Unlock_Buttons[3].SetActive(false);
            Use_Buttons[3].SetActive(true);
        }
    }

    public void Use_Charecter(string Charecter)
    {
        text_default();
        switch (Charecter)
        {
            case "Bear":
                //Debug.Log("Bear");
                if (PlayerPrefs.GetString("MainPlayer", "none") == "Bear")
                {
                    PlayerPrefs.SetString("MainPlayer", "none");
                    using_text[0].text = "Use";
                }
                else
                {
                    PlayerPrefs.SetString("MainPlayer", "Bear");
                    using_text[0].text = "////";
                }
                break;
            case "Cheetah":
                //Debug.Log("Cheetah");
                if (PlayerPrefs.GetString("MainPlayer", "none") == "Cheetah")
                {
                    PlayerPrefs.SetString("MainPlayer", "none");
                    using_text[1].text = "Use";
                }
                else
                {
                    PlayerPrefs.SetString("MainPlayer", "Cheetah");
                    using_text[1].text = "////";
                }
                break;
            case "Leapord":
                //Debug.Log("Leopard");
                if (PlayerPrefs.GetString("MainPlayer", "none") == "Leapord")
                {
                    PlayerPrefs.SetString("MainPlayer", "none");
                    using_text[2].text = "Use";
                }
                else
                {
                    PlayerPrefs.SetString("MainPlayer", "Leapord");
                    using_text[2].text = "////";
                }
                
                break;
            case "Tiger":
                //Debug.Log("Tiger");
                if (PlayerPrefs.GetString("MainPlayer", "none") == "Tiger")
                {
                    PlayerPrefs.SetString("MainPlayer", "none");
                    using_text[3].text = "Use";
                }
                else
                {
                    PlayerPrefs.SetString("MainPlayer", "Tiger");
                    using_text[3].text = "////";
                }
                break;
            default :
                break;
        }
    }

    private void text_default()
    {
        for(int i = 0; i<using_text.Length;i++)
        {
            using_text[i].text = "Use";
        }
    }

    //Ending charecter switching

    public void fertilizer_time(int time)
    {
        if (coin_IsSpent)
        {
            coin_IsSpent = false;
            //Debug.Log("Set time : " + time);
            PlayerPrefs.SetInt("Fertilizer_Time", time+PlayerPrefs.GetInt("Fertilizer_Time",0));
            //Debug.Log(PlayerPrefs.GetInt("Fertilizer_Time", 0));
        }
    }

    public void Energy(int energy)
    {
        if (coin_IsSpent)
        {
            coin_IsSpent = false;
            //Debug.Log("Energy initials" + energy);

            PlayerPrefs.SetInt("Energy_percent",PlayerPrefs.GetInt("Energy_percent",0)+energy);
        }
    }

    public void Gem_Pack()
    {
        if (coin_IsSpent)
        {
            coin_IsSpent = false;

            PlayerPrefs.SetInt("Gem_pack",1);

        }
    }

    public void Freeze()
    {
        if (coin_IsSpent)
        {
            coin_IsSpent = false;

            PlayerPrefs.SetInt("Freeze", 1);
        }
    }
}
