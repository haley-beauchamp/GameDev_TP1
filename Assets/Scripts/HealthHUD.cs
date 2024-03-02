using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHUD : MonoBehaviour
{
    public Text HealthText;
    void Start()
    {
        HealthText.text = "HP: " + playerHealth.playerHP.ToString();
    }

    void Update()
    {
        HealthText.text = "HP: " + playerHealth.playerHP.ToString();
    }
    
}
