using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textStuff : MonoBehaviour
{
    public Text bigTextBox;

    public void noKeyWarn()
    {
        bigTextBox.text = "You dont have a key. Maybe you should explore the area";
    }

    public void clearText()
    {
        bigTextBox.text = "";
    }
}
