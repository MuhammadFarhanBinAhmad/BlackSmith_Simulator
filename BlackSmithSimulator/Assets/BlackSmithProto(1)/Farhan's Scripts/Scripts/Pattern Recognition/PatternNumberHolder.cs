using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternNumberHolder : MonoBehaviour
{
    public PatternRecognitionData the_Pattern_Recognition_Data;
    public int this_Object_Number;

    private void Start()
    {
        this_Object_Number = the_Pattern_Recognition_Data.number_Position;//set number
    }
}
