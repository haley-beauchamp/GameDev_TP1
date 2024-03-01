using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class signScript : MonoBehaviour
{
    public bool isInRange;
    [SerializeField] Text signText; 

    void Update()
    {
        if (isInRange)
        {
            signText.text = "!Warning!\nDangerous Cave Ahead\nP.S. I Have Hidden The Key To The Cave Somewhere High Where Nobody Can Reach It";
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            signText.text = "";
        }
    }
}
