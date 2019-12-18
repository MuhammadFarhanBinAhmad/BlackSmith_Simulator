using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name =="Hand")
        {
            GetComponent<MeshRenderer>().material.color = new Color(.75f, .75f, .75f, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Hand")
        {
            GetComponent<MeshRenderer>().material.color = new Color(1, 1, 1, 1);
        }
    }
}
