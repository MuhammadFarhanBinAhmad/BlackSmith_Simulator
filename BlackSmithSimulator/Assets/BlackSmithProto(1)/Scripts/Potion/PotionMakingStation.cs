using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionMakingStation : PotionRuneManager
{
    private void FixedUpdate()
    {
        //All Combination for Potion
        if (catalyst == "Magnesium")
        {
            if (ingredient == "FireIngredient")
            {
                current_Type = 0;
            }
            if (ingredient == "IceIngredient")
            {
                current_Type = 1;
            }
            if (ingredient == "WindIngredient")
            {
                current_Type = 2;
            }
        }
        if (catalyst == "Sodium")
        {
            if (ingredient == "FireIngredient")
            {
                current_Type = 3;
            }
            if (ingredient == "IceIngredient")
            {
                current_Type = 4;
            }
            if (ingredient == "WindIngredient")
            {
                current_Type = 5;
            }
        }
        if (catalyst != "" && ingredient != "")
        {
            InstantiatePotion();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //detect if gameobject in contact with is a catalyst
        if (other.tag == "Catalyst")
        {
            print("HIT");
            //if nothing is present, will take the spot of new catalyst
            if (catalyst == "")
            {
                if (other.name == "Magnesium")
                {
                    catalyst = "Magnesium";
                }
                if (other.name == "Sodium")
                {
                    catalyst = "Sodium";
                }
            }
        }
        //if nothing is present, will take the spot of new Ingredient
        else if (other.tag == "Herb")
        {
            if (ingredient == "")
            {
                if (other.name == "FireHerb")
                {
                    ingredient = "FireHerb";
                }
                if (other.name == "IceHerb")
                {
                    ingredient = "IceHerb";
                }
                if (other.name == "WindHerb")
                {
                    ingredient = "WindHerb";
                }
            }
        }
    }
}

