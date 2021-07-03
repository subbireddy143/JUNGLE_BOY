using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Tut_Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jump_speed;
    private int jump_count;
    public GameObject ready_p;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump_speed = 200f;
        jump_count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
            jump_count = 0;
        //Button Functionings
        if (CrossPlatformInputManager.GetButtonDown("Jump") && (IsGrounded() || jump_count < 1))
        {
            jump_count++;
            //anim.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jump_speed * 1.3f);
            Sound_Manager.playSound("jump");
        }
        if (CrossPlatformInputManager.GetButtonDown("Fall"))
        {
            rb.AddForce(Vector2.down * jump_speed * 3);
        }
        if (CrossPlatformInputManager.GetButtonDown("Double_Jump") && IsGrounded())
        {
            jump_count++;
            //anim.SetBool("isJumping", true);
            rb.AddForce(Vector2.up * jump_speed * 2);
            Sound_Manager.playSound("jump");
        }

    }
    private bool IsGrounded()
    {
        return (transform.Find("Ground_Check").GetComponent<Ground_Check>().isGrounded);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "End_Tut") {
            ready_p.SetActive(false);
        }
    }
}
