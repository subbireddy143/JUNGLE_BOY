using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Header : MonoBehaviour
{
    [SerializeField]
    private Button Coin, Gem, Exchange, Premium;

    [SerializeField]
    private GameObject Coin_P, Gem_P, Exchange_P, Premium_P;

    


    private void Start()
    {
        
    }
    public void make_inactive() {
        

        //Set all panels inactve
        Coin_P.SetActive(false);
        Gem_P.SetActive(false);
        Exchange_P.SetActive(false);
        Premium_P.SetActive(false);
    }

     public void Working_P(GameObject Content)
    {
        make_inactive();
        Content.SetActive(true);

    }
}
