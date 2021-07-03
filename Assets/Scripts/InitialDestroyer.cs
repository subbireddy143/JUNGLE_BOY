using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialDestroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Freeze") || collision.gameObject.CompareTag("Broom") || collision.gameObject.CompareTag("Gem")) {
            Destroy(collision.gameObject);
        }
    }
}
