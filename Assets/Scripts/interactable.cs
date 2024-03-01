using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public UnityEvent deNotifyPlayer;
    public bool interactHappened = false;

    void Update()
    {
        if (!interactHappened)
        {
            if (isInRange)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    deNotifyPlayer.Invoke();
                    interactAction.Invoke();
                    interactHappened = true;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!interactHappened)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = true;
                collision.gameObject.GetComponent<PlayerMovement>().notifyPlayer();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!interactHappened)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                isInRange = false;
                collision.gameObject.GetComponent<PlayerMovement>().denotifyPlayer();
            }
        }
    }
}
