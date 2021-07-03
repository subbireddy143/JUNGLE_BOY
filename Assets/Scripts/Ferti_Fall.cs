using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferti_Fall : MonoBehaviour
{
    public GameObject Fertilizer;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Instantiate_Ferti",1f,0.5f);
    }

    private void Instantiate_Ferti()
    {
        Instantiate(Fertilizer, transform.position, transform.rotation);
    }
}
