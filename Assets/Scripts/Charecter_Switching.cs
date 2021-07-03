using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charecter_Switching : MonoBehaviour
{
    public GameObject[] Charecter;
    // Start is called before the first frame update
    void Start()
    {
        set_Inactive();
        Charecter[PlayerPrefs.GetInt("Charecter_Select", 2)].SetActive(true);
    }

    void set_Inactive() {
        for (int i = 0; i < Charecter.Length; i++) {
            Charecter[i].SetActive(false);
        }
    }
}
