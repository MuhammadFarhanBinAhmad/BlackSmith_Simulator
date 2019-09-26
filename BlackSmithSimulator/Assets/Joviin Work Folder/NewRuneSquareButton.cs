using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRuneSquareButton : MonoBehaviour
{
    public int thisButtonNumber;

    public void OnButtonPressed()
    {
        Debug.Log("Button " + thisButtonNumber + " has been pressed");
        this.GetComponent<Button>().interactable = false;
        FindObjectOfType<NewRuneSquareMaster>().NumberSequenceList(thisButtonNumber);
    }

    public void ReleaseButton()
    {
        this.GetComponent<Button>().interactable = true;
        Debug.Log("Button" + thisButtonNumber + " has been released");
    }

}
