using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRecognition : MonoBehaviour
{
    public List<int> number_Code = new List<int>();//hold the number pattern


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PatternNumberHolder>().this_Object_Number != 0)
        {
            number_Code.Add(GetComponent<PatternNumberHolder>().this_Object_Number);
        }
    }
}
