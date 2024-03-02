using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitButton : MonoBehaviour
{
    public void rageQuit()
    {
        playerHealth.playerHP = 5;
        nextScene.currentLevel = 1;
        Application.Quit();
    }
}
