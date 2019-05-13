using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitting : MonoBehaviour
{
    public bool can_Hit;

    public void Hittin()
    {
        if (can_Hit)
        {
            FindObjectOfType<Ore>().time_Hit_Needed--;
            print("Hitting");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ore")
        {
            can_Hit = true;
            print("In");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ore")
        {
            can_Hit = false;
        }
    }
}
