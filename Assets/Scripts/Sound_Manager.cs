using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    public static AudioClip coin_pick, jump, land;
    static AudioSource audio_src;
    // Start is called before the first frame update
    void Start()
    {
        coin_pick = Resources.Load<AudioClip>("Coin-pickup-sound");
        jump = Resources.Load<AudioClip>("Jump");
        land = Resources.Load<AudioClip>("Land");

        audio_src = GetComponent<AudioSource>();
    }

    public static void playSound(string clip) {
        switch (clip) {
            case "jump":
                audio_src.PlayOneShot(jump);
                break;
            case "land":
                audio_src.PlayOneShot(land);
                break;
            case "coin_pick":
                audio_src.PlayOneShot(coin_pick);
                break;

        }
    }

   
}
