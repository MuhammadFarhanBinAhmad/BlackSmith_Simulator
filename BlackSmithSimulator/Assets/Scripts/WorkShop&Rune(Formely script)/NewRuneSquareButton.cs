using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRuneSquareButton : MonoBehaviour
{
    public int thisButtonNumber;
    public Vector3 thisButtonPos;

    public void Start()
    {
        thisButtonPos = new Vector3(this.GetComponent<RectTransform>().localPosition.x, this.GetComponent<RectTransform>().localPosition.y, 0);
    }

    public void OnButtonPressed()
    {
        //Debug.Log("Button " + thisButtonNumber + " has been pressed");
        this.GetComponent<Button>().interactable = false;
        FindObjectOfType<NewRuneSquareMaster>().NumberSequenceList(thisButtonNumber);
        FindObjectOfType<RuneSquareLineRenderer>().CreateRuneLine(thisButtonPos);
    }

    public void ReleaseButton()
    {
        this.GetComponent<Button>().interactable = true;
        //Debug.Log("Button" + thisButtonNumber + " has been released");
    }

}
