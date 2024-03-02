using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    private Animator animator;

    public static int playerHP = 5;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHP == 0) 
        {
            animator.SetBool("Death", true);
            GemScript.score -= 50;
            PlayerMovement.playerDead = true;
            SceneManager.LoadScene("playerDead");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("spikes"))
        {
            playerHP = 0;
            GemScript.score -= 100;
        }
    }
}
