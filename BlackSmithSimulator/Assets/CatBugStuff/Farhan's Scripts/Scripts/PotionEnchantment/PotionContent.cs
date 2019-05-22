using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionContent : MonoBehaviour
{
    public PotionTypeData the_Potion_Type_Data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            other.GetComponent<ThisWeaponData>().this_Enchantment_Percentage++;//plus one to enchantment status
            //check if weapon is enchanted or not. If not, then it will be enchanted by what type of potion being pour on
            if (other.GetComponent<ThisWeaponData>().this_Enchantment_Percentage == 100)
            {
                other.GetComponent<ThisWeaponData>().this_Enchantment_Type = the_Potion_Type_Data.Potion_Enchantment_Type;
            }
            Destroy(this.gameObject);
            print("HIt");
        }
    }

    
}
