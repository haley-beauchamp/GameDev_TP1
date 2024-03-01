using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class doorInteraction : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public UnityEvent deNotifyPlayer;
    public bool interactHappened = false;

    public GameObject textStuffObject;
    private textStuff textStuff;

    void Start()
    {
        textStuff = textStuffObject.GetComponent<textStuff>();
    }

    void Update()
    {
        if (!interactHappened)
        {
            if (isInRange)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    deNotifyPlayer.Invoke();
                    if (keyScript.playerHasKey)
                    {
                        interactAction.Invoke();
                        interactHappened = true;
                    } else if (!keyScript.playerHasKey)
                    {
                        textStuff.noKeyWarn();
                    }
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
                if (!keyScript.playerHasKey)
                {
                    textStuff.clearText();
                }
            }
        }
    }
}
