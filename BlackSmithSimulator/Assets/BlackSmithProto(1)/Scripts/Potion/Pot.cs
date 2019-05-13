using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    //ingredients
    public string catalyst,herb;


    public GameObject[] potion = new GameObject[6];
    public List<string> potion_Name = new List<string>();
    public int current_potion;

    public void EmptyPot()
    {
        catalyst = "";
        herb = "";
    }
    private void FixedUpdate()
    {
        if (catalyst == "Magnesium")
        {
            if (herb == "FireHerb")
            {
                current_potion = 0;
            }
            if (herb == "IceHerb")
            {
                current_potion = 1;
            }
            if (herb == "WindHerb")
            {
                current_potion = 2;
            }
        }
        if (catalyst == "Sodium")
        {
            if (herb == "FireHerb")
            {
                current_potion = 3;
            }
            if (herb == "IceHerb")
            {
                current_potion = 4;
            }
            if (herb == "WindHerb")
            {
                current_potion = 5;
            }
        }
        if (catalyst != "" && herb !="")
        {
            InstantiatePotion();
        }
    }

    void InstantiatePotion()
    {
        GameObject P = Instantiate(potion[current_potion], transform.position, transform.rotation);
        ResetRecipe();
        print("hit");
    }

    void ResetRecipe()
    {
        catalyst = "";
        herb = "";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag =="Catalyst")
        {
            if (catalyst == "")
            {
                if (other.name == "Magnesium")
                {
                    catalyst = "Magnesium";
                }
                if  (other.name == "Sodium")
                {
                    catalyst = "Sodium";
                }
            }
        }
        if (other.tag == "Herb")
        {
            if (herb == "")
            {
                if (other.name == "FireHerb")
                {
                    herb = "FireHerb";
                }
                if (other.name == "IceHerb")
                {
                    herb = "IceHerb";
                }
                if (other.name == "WindHerb")
                {
                    herb = "WindHerb";
                }
            }
        }
    }
}
