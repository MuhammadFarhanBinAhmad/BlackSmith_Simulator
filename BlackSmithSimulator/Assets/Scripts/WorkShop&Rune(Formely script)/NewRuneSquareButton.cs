using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewRuneSquareButton : MonoBehaviour
{
    public int thisButtonNumber;
    public Vector3 thisButtonPos;
    public GameObject sparkle;

    public void Start()
    {
        thisButtonPos = new Vector3(this.GetComponent<RectTransform>().localPosition.x, this.GetComponent<RectTransform>().localPosition.y, 0);
    }

    public void OnButtonPressed()
    {
        //Debug.Log("Button " + thisButtonNumber + " has been pressed");
        this.GetComponent<Button>().interactable = false;
        this.GetComponent<Image>().color = Color.yellow;
        FindObjectOfType<NewRuneSquareMaster>().NumberSequenceList(thisButtonNumber);
        FindObjectOfType<RuneSquareLineRenderer>().CreateRuneLine(thisButtonPos);
        Instantiate(sparkle, thisButtonPos, Quaternion.identity);
    }

    public void ReleaseButton()
    {
        this.GetComponent<Image>().color = Color.white;
        this.GetComponent<Button>().interactable = true;
        //Debug.Log("Button" + thisButtonNumber + " has been released");
    }

}
