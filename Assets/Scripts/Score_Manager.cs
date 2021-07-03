using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour
{
    public Text highSurvivalTime, SurvivalTime;
    public float survivalTime,highsurvivalTime;

   
    // Start is called before the first frame update
    void Start()
    {
        survivalTime = 0;
        //Getting back highest survival time
        highsurvivalTime = PlayerPrefs.GetFloat("H_S_T",0);
        highSurvivalTime.text = highsurvivalTime.ToString("0");
    }

    // Update is called once per frame
    void Update()
    {
        //survival time updation
        survivalTime += Time.deltaTime;
        SurvivalTime.text = survivalTime.ToString("0");
        if (survivalTime > highsurvivalTime) {
            highsurvivalTime = survivalTime;
            highSurvivalTime.text = highsurvivalTime.ToString("0");
        }

        //Storing highest survival time
        PlayerPrefs.SetFloat("H_S_T",highsurvivalTime);

        if (Time.timeScale !=0) {
            Time.timeScale = 1 + (survivalTime/750);
        }
    }
}
