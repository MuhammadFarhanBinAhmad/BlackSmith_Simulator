using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemCheck : MonoBehaviour
{
    public bool runeItemCheck;
    public bool weaponItemCheck;
    public bool weaponenchantedItemCheck;

    void Start()
    {
        runeItemCheck = false;
        weaponItemCheck = false;
        weaponenchantedItemCheck = false;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RuneData>() != null)
        {
            runeItemCheck = true;
        }

        if (other.GetComponent<ThisWeaponData>() != null)
        {
            weaponItemCheck = true;

            if (other.GetComponent<ThisWeaponData>().this_Material_Type != 0 && other.GetComponent<ThisWeaponData>().this_Weapon_Type != 0 && other.GetComponent<ThisWeaponData>().this_Enchantment_Type != 0)
            {
                weaponenchantedItemCheck = true;
            }
        }
    }
}
