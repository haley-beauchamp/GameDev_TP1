using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyScript : MonoBehaviour
{
    public static bool playerHasKey = false;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Has Key");
            playerHasKey = true;
            Destroy(this.gameObject);
        }
    }
}
