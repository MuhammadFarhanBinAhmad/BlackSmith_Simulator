using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMaker : MonoBehaviour
{
    //ingredient currently in pot
    public int catalyst_In_Pot, herb_In_Pot;
    //current potion type
    public int current_Type;
    //Potion to spawn
    public GameObject[] potion_Types = new GameObject[7];
    //Catalyst number
    //Magnesium = 1,Sodium = 2
    //Herb Number
    //Fire = 1,Ice = 2,Wind = 3
    private void FixedUpdate()
    {
        //All Combination for Potion
        if (catalyst_In_Pot == 1)
        {
            if (herb_In_Pot == 1)
            {
                current_Type = 1;
            }
            if (herb_In_Pot == 2)
            {
                current_Type = 2;
            }
            if (herb_In_Pot == 3)
            {
                current_Type = 3;
            }
        }
        if (catalyst_In_Pot == 2)
        {
            if (herb_In_Pot == 1)
            {
                current_Type = 4;
            }
            if (herb_In_Pot == 2)
            {
                current_Type = 5;
            }
            if (herb_In_Pot == 3)
            {
                current_Type = 6;
            }
        }
        if (catalyst_In_Pot != 0 && herb_In_Pot != 0)
        {
            GameObject P = Instantiate(potion_Types[current_Type], transform.position, transform.rotation);
            EmptyPot();
        }
    }
    public void EmptyPot()
    {
        catalyst_In_Pot = 0;
        herb_In_Pot = 0;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "herbs")
        {
            herb_In_Pot = other.GetComponent<CatalystHerb>().this_Object_Herb;
            print("Hit");
        }
        if (other.tag == "PotionCatalyst")
        {
            print("Hit");
            catalyst_In_Pot = other.GetComponent<CatalystHerb>().this_Object_Catalyst;
        }
        
    }
}
