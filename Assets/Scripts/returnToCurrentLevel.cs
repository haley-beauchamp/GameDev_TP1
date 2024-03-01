using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToCurrentLevel : MonoBehaviour
{

    public void returnToLevel()
    {
        PlayerMovement.playerDead = false;
        playerHealth.playerHP = 5;
        SceneManager.LoadScene(nextScene.currentLevel);
    }
}