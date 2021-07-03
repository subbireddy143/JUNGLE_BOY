using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self_Destruction : MonoBehaviour
{
    [SerializeField]
    private float Time_Count;
    // Start is called before the first frame update
    void Start()
    {
        //Time_Count = 10f;
        Destroy(gameObject,Time_Count);
    }

    
}
