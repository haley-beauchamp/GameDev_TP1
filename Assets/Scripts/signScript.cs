using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class signScript : MonoBehaviour
{
    public bool isInRange;
    [SerializeField] Text signText;
    [SerializeField] string textForSign;
    [SerializeField] Canvas canvas;
    [SerializeField] bool shouldRemoveCanvas = false;

    void Start()
    {
        if (shouldRemoveCanvas)
        {
            canvas.enabled = false;
        }
    }

    void Update()
    {
        if (isInRange)
        {
            signText.text = textForSign.Replace("\\n", "\n");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            if (shouldRemoveCanvas)
            {
                canvas.enabled = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            signText.text = "";

            if (shouldRemoveCanvas)
            {
                canvas.enabled = false;
            }
        }
    }
}