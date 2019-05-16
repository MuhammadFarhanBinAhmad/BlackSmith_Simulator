using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneMaker : MonoBehaviour
{
    //ingredient currently in Dispenser
    public int catalyst_In_Dispenser, reactant_In_Dispenser;
    //current Rune type
    public int current_Type;
    //Potion to spawn
    public GameObject[] Rune_Types = new GameObject[8];
    //Catalyst number
    //Calcium = 1,Nitrate = 2
    //Herb Number
    //Copper = 1,Iron = 2,Gold = 3,Alloy = 4
    private void FixedUpdate()
    {
        //All Combination for Potion
        if (catalyst_In_Dispenser == 1)
        {
            if (reactant_In_Dispenser == 1)
            {
                current_Type = 1;
            }
            if (reactant_In_Dispenser == 2)
            {
                current_Type = 2;
            }
            if (reactant_In_Dispenser == 3)
            {
                current_Type = 3;
            }
            if (reactant_In_Dispenser == 4)
            {
                current_Type = 4;
            }
        }
        if (catalyst_In_Dispenser == 2)
        {
            if (reactant_In_Dispenser == 1)
            {
                current_Type = 5;
            }
            if (reactant_In_Dispenser == 2)
            {
                current_Type = 6;
            }
            if (reactant_In_Dispenser == 3)
            {
                current_Type = 7;
            }
            if (reactant_In_Dispenser == 4)
            {
                current_Type = 8;
            }
        }
        if (catalyst_In_Dispenser != 0 && reactant_In_Dispenser != 0)
        {
            GameObject P = Instantiate(Rune_Types[current_Type], transform.position, transform.rotation);
            EmptyPot();
        }
    }
    public void EmptyPot()
    {
        catalyst_In_Dispenser = 0;
        reactant_In_Dispenser = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reactant")
        {
            reactant_In_Dispenser = other.GetComponent<EmptyRuneData>().this_Object_Reactant;
            print("Hit");
        }
        if (other.tag == "RuneCatalyst")
        {
            print("Hit");
            catalyst_In_Dispenser = other.GetComponent<EmptyRuneData>().this_Object_Catalyst;
        }

    }
}
