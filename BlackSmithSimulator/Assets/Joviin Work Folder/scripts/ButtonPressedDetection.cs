using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class ButtonPressedDetection : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public string outputOnMax = "Maximum Reached";
    public string outputOnMin = "Minimum Reached";
    public int thisObjectNumber; 

    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {

    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        //when pressed
        print("Button " + thisObjectNumber + " has been pressed");

        FindObjectOfType<PatternRecognition>().number_Receive = thisObjectNumber;//send number to PatternRecognition
        FindObjectOfType<PatternRecognition>().NumberHolder(); //send number to PatternRecognition
    }

    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {

    }
}
