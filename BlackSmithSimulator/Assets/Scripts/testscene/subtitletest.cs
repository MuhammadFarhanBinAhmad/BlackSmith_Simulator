using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class subtitletest : MonoBehaviour
{
    public Text textBox;
    public TextMeshProUGUI tmProGUI;
    

    private void Start()
    {
        InvokeRepeating("PrintText", 1, 2);
    }

    void PrintText()
    {
        //textBox.text = textBox.text + ("this is the first line \n this is the second line \n");
        tmProGUI.text = tmProGUI.text + ("this is the first line \n this is the second line \n");

        if (tmProGUI.text.Length > 1)
        {
            
        }
    }
}
