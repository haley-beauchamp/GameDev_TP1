using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextScene : MonoBehaviour
{
    public static int currentLevel = 0;

    public void nextLevel()
    {
        currentLevel++;
        Debug.Log(currentLevel.ToString());
        SceneManager.LoadScene(currentLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        nextLevel();
    }
}
