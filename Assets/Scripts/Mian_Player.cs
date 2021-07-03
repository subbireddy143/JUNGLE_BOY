using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Mian_Player : MonoBehaviour
{
    //private Animator anim;

    private Rigidbody2D rb;
    private float jump_speed;
    private int jump_count;

    public GameObject[] Badges_XP, Badges_HXP;
    public Image H_XP, XP;
    public int H_badge, badge;

    private int Coin_Count;
    public Text coin_txt;

    private int Gem_Count;
    public Text gem_txt;

    [SerializeField]
    private GameObject Freezed_Floor;
    Vector3 freeze_pos;
    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        jump_speed = 200f;
        jump_count = 0;

        badge_inactive();
        //PlayerPrefs.SetInt("H_Badge",0);
        H_badge = PlayerPrefs.GetInt("H_Badge",0);
        badge = 0;
        Badges_XP[badge].SetActive(true);
        Badges_HXP[H_badge].SetActive(true);
        H_XP.fillAmount = PlayerPrefs.GetFloat("fillHXp",0);
        XP.fillAmount = 0 ;

        //PlayerPrefs.SetInt("Coins",100);//to reset the coin count
        Coin_Count = PlayerPrefs.GetInt("Coins", 100);
        PlayerPrefs.SetInt("Coins",Coin_Count);
        coin_txt.text = Coin_Count.ToString();

        //PlayerPrefs.SetInt("Gems",100);//to reset the gem count
        Gem_Count = PlayerPrefs.GetInt("Gems", 20);
        PlayerPrefs.SetInt("Gems",Gem_Count);
        gem_txt.text = Gem_Count.ToString();

        //storing the initial position of freeze
        freeze_pos = Freezed_Floor.GetComponent<Transform>().position;
        freeze_pos.x = freeze_pos.x + 80;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded()) 
            jump_count = 0;
        //Button Functionings
        if (CrossPlatformInputManager.GetButtonDown("Jump") && (IsGrounded() || jump_count <1)) {
            jump_count++;
            //anim.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jump_speed*1.3f);
            Sound_Manager.playSound("jump");
        }
        if (CrossPlatformInputManager.GetButtonDown("Fall"))
        {
            rb.AddForce(Vector2.down * jump_speed*3);
        }
        if (CrossPlatformInputManager.GetButtonDown("Double_Jump") && IsGrounded())
        {
            jump_count++;
            //anim.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jump_speed*2);
            Sound_Manager.playSound("jump");
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "XP" && XP.fillAmount != 1 && badge <15) {
            //Destroy(collision.gameObject);
            XP.fillAmount += 0.05f;
            
            if (H_badge == badge && H_XP.fillAmount<= XP.fillAmount) {
                H_XP.fillAmount = XP.fillAmount;
                PlayerPrefs.SetFloat("fillHXp",H_XP.fillAmount);
            }
        }
        if (collision.gameObject.tag == "XP" && XP.fillAmount == 1 && badge < 15)
        {
            //Destroy(collision.gameObject);
            badge_inactive();
            if (badge < 15)
                XP.fillAmount = 0;
            if (badge == 15)
                XP.fillAmount = 1f;
            H_badge = PlayerPrefs.GetInt("H_Badge",H_badge);
            if (badge < 15) {
                badge++;
            }

            if (H_badge < badge) {
                H_badge = badge;
                PlayerPrefs.SetInt("H_Badge", H_badge);
                H_XP.fillAmount = 0;
                PlayerPrefs.SetFloat("fillHXp", H_XP.fillAmount);
            }
                
            Badges_XP[badge].SetActive(true);
            Badges_HXP[H_badge].SetActive(true);
            
            
        }

        if (collision.gameObject.tag == "Coin")
        {
            //Destroy(collision.gameObject);
            Sound_Manager.playSound("coin_pick");
            Coin_Count = PlayerPrefs.GetInt("Coins");
            Coin_Count++;
            coin_txt.text = Coin_Count.ToString();
            PlayerPrefs.SetInt("Coins", Coin_Count);
            Debug.Log(Coin_Count);
        }

        if (collision.gameObject.tag == "Gem")
        {
            //Destroy(collision.gameObject);
            Sound_Manager.playSound("coin_pick");//gem sound
            Gem_Count = PlayerPrefs.GetInt("Gems");
            Gem_Count++;
            gem_txt.text = Gem_Count.ToString();
            PlayerPrefs.SetInt("Gems", Gem_Count);
            Debug.Log(Gem_Count);
        }

        if (collision.gameObject.tag == "Freeze") {
            //Destroy(collision.gameObject);
            Freezed_Floor.GetComponent<Transform>().position = freeze_pos; 
            Freezed_Floor.SetActive(true);
        }
    }
    private bool IsGrounded() {
        return (transform.Find("Ground_Check").GetComponent<Ground_Check>().isGrounded);
    }
    
    private void badge_inactive() {
        //Set all badges inactive
        for (int i = 0; i <= 15; i++)
        {
            Badges_HXP[i].SetActive(false);
            Badges_XP[i].SetActive(false);
        }
    }
}
