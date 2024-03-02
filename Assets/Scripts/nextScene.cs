using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public static int currentLevel = 0;

    public void nextLevel()
    {
        if (currentLevel == 5)
        {
            currentLevel = 0;
            playerHealth.playerHP = 5;
            PlayerMovement.playerDead = false;
            GemScript.score = 0;
            SceneManager.LoadScene(currentLevel);
        }
        currentLevel++;
        Debug.Log(currentLevel.ToString());
        SceneManager.LoadScene(currentLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nextLevel();
    }
}