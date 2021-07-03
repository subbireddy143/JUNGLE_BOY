using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons_Manager : MonoBehaviour
{
    public Transform Player;
    public float right_speed;
    

    void Start()
    {
        right_speed = 10;
        
    }

    public void right() {
        if (Player.position.x <= 6f) {
            Player.transform.Translate(right_speed * Time.deltaTime, 0, 0);
        }
        
    }
    public void left()
    {
        if (Player.position.x > -9f)
        {
            Player.transform.Translate(-right_speed * Time.deltaTime, 0, 0);
        }

    }
    
}
