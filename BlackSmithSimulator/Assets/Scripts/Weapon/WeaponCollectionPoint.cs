using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectionPoint : MonoBehaviour
{
    public bool ready_For_Collection;

    public int weapon_Type;
    public int material_Type;
    public int enchantment_Type;

    public ThisWeaponData created_Weapon;
    //check if the order is correct
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ThisWeaponData>() != null)
        {
            created_Weapon = other.GetComponent<ThisWeaponData>();
            weapon_Type = created_Weapon.this_Weapon_Type;
            material_Type = created_Weapon.this_Material_Type;
            enchantment_Type = created_Weapon.this_Enchantment_Type;
            ready_For_Collection = true;
        }
    }
}
