using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternNumberHolder : MonoBehaviour
{
    public int this_Object_Number;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Hand")
        {
            SendNumber();
        }
    }
    public void SendNumber()
    {
        FindObjectOfType<PatternRecognition>().number_Receive = this_Object_Number;//send number to PatternRecognition
        FindObjectOfType<PatternRecognition>().NumberHolder();
    }
}
