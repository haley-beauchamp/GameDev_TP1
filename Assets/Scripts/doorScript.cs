using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class doorScript : MonoBehaviour
{
    public void doorOpen()
    {
        if (keyScript.playerHasKey)
        {
            for (int i = 0; i < 5; i++)
            {
                transform.position += Vector3.down * 1 * Time.deltaTime;
            }
            Destroy(gameObject);
        } 
    }
}
