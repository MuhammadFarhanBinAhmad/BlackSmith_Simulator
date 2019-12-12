using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectionPoint : MonoBehaviour
{
    public bool ready_For_Collection;

    public int weapon_Type;
    public int material_Type;
    public int enchantment_Type;

    //check if the order is correct
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ThisWeaponData>() != null)
        {
            weapon_Type = other.GetComponent<ThisWeaponData>().this_Weapon_Type;
            material_Type = other.GetComponent<ThisWeaponData>().this_Material_Type;
            enchantment_Type = other.GetComponent<ThisWeaponData>().this_Enchantment_Type;
            ready_For_Collection = true;
        }
    }
}
