using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ferti_Working : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "floor") {
            Destroy(gameObject);
        }
    }
}
