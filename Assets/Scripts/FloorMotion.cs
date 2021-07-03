using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMotion : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed*Time.deltaTime,0,0); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Floor_Terminate")) {
            //To terminate the floor after it crosses scene
            Debug.Log("Terminate");
            Destroy(this.gameObject);
        }
    }
}
