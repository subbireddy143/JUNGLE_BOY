using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class Adcaller : MonoBehaviour
{

    private string adid = "3539044"; // you need this id to display ads on Android or IOS

    private string videoad = "video"; // the type of ad you want to display

    //Start is called before the first frame update  
    void Start()
    {
        Advertisement.Initialize(adid, true);
    }

    //Update is called once per frame
    public void Adshower()
    {
        if (Advertisement.IsReady(videoad))
        {
            Advertisement.Show(videoad);
        }
    }
}
