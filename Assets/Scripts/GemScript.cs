using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour
{
    public AudioSource audioSource;
    public int increment;
    public static int score = 0;


    void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            audioSource.Play();
            ScoreHUD.instance.IncreaseScore(increment);
        }
    }
}
