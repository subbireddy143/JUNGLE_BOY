using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ground_Check : MonoBehaviour
{
    public Animator anim;
    public GameObject play_panel;
    public GameObject Game_Over;
    public bool isGrounded;
    [SerializeField] private LayerMask Floor;

    private string adid = "3539044";
    private string videoad = "video";

    //as the sound is not proper
    public GameObject Ground_Sound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        isGrounded = true;

        Advertisement.Initialize(adid, true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = collision != null && (((1<< collision.gameObject.layer) & Floor) != 0) ;
        if (collision != null && (((1 << collision.gameObject.layer) & Floor) != 0))
        {
            Ground_Sound.SetActive(true);
            anim_Control();
            //anim.SetBool("isJumping", false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Ground_Sound.SetActive(false);
        anim.SetBool("isJumping", true);
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && (((1 << collision.gameObject.layer) & Floor) != 0))
        {
            Sound_Manager.playSound("land");
        }
        if (collision.gameObject.tag == "Fire") {
            Time.timeScale = 0;
            play_panel.SetActive(false);
            Game_Over.SetActive(true);
            if (Advertisement.IsReady(videoad))
            {
                Advertisement.Show(videoad);
            }
        }
    }
    private void anim_Control() {
        anim.SetBool("isJumping", false);
    }
}
