using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_Continous : MonoBehaviour
{
    public GameObject coin_Set;
    
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("conti_Coins",1f,.5f);
    }

    void conti_Coins() {
        Instantiate(coin_Set,transform.position,transform.rotation);
    }
}
