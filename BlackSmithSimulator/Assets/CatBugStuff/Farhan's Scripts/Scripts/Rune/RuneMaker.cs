using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneMaker : MonoBehaviour
{
    //ingredient currently in Dispenser
    public int catalyst_In_Dispenser, reactant_In_Dispenser;
    //current Rune type
    public int current_Type;

    public GameObject[] Rune_Types = new GameObject[9];
    GameObject catalystReference = null;
    GameObject reactantReference = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reactant")
        {
            reactant_In_Dispenser = other.GetComponent<EmptyRuneData>().this_Object_Reactant;
            print("Reactant Detected");
            CheckRune();
        }
        if (other.tag == "RuneCatalyst")
        {
            print("RuneCatalyst Dectected");
            catalyst_In_Dispenser = other.GetComponent<EmptyRuneData>().this_Object_Catalyst;
            CheckRune();
        }
        //if (other.GetComponent<EmptyRuneData>() != null)
        //{
        //    if (other.GetComponent<EmptyRuneData>().this_Object_Catalyst != 0)
        //    {
        //        catalystReference = other.gameObject;
        //        catalyst_In_Dispenser = catalystReference.GetComponent<EmptyRuneData>().this_Object_Catalyst;
        //        CheckRune();
        //    }

        //    if (other.GetComponent<EmptyRuneData>().this_Object_Reactant != 0)
        //    {
        //        catalystReference = other.gameObject;
        //        reactant_In_Dispenser = reactantReference.GetComponent<EmptyRuneData>().this_Object_Reactant;
        //        CheckRune();
        //    }
        //}

    }

    //private void OnTriggerExit(Collider other)
    //{
    //    //Remove Base Rune if left RuneMaker
    //    if (other.GetComponent<EmptyRuneData>() != null)
    //    {
    //        if (other.GetComponent<EmptyRuneData>().this_Object_Catalyst != 0 || other.gameObject == catalystReference)
    //        {
    //            catalystReference = null;
    //            catalyst_In_Dispenser = 0;
    //        }

    //        if (other.GetComponent<EmptyRuneData>().this_Object_Reactant != 0 || other.gameObject == reactantReference)
    //        {
    //            reactantReference = null;
    //            reactant_In_Dispenser = 0;
    //        }

    //    }
    //}

    void CheckRune()
    {
        if (catalyst_In_Dispenser != 0 && reactant_In_Dispenser != 0)
        {
            //All Combination for runes
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
            if (catalyst_In_Dispenser == 3)
            {
                if (reactant_In_Dispenser == 1)
                {
                    current_Type = 9;
                }
                if (reactant_In_Dispenser == 2)
                {
                    current_Type = 10;
                }
                if (reactant_In_Dispenser == 3)
                {
                    current_Type = 11;
                }
                if (reactant_In_Dispenser == 4)
                {
                    current_Type = 12;
                }
            }
            if (current_Type != 0)
            {
                GameObject P = Instantiate(Rune_Types[current_Type], transform.position, transform.rotation);
                EmptyPot();
            }
        }
    }

    public void EmptyPot()
    {
        catalyst_In_Dispenser = 0;
        reactant_In_Dispenser = 0;
        Destroy(catalystReference);
        Destroy(reactantReference);
        catalystReference = null;
        reactantReference = null;
        current_Type = 0;
    }
}
