using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemCheck : MonoBehaviour
{
    public bool runeItemCheck;
    public bool weaponItemCheck;
    public bool weaponenchantedItemCheck;

    public GameObject[] tickImages;

    GameObject weaponRef;

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
            tickImages[0].SetActive(true);
        }

        if (other.GetComponent<ThisWeaponData>() != null)
        {
            weaponItemCheck = true;
            tickImages[1].SetActive(true);
            weaponRef = other.gameObject;
            WeaponCompletedCheck();
        }
    }

    public void WeaponCompletedCheck()
    {
        if (weaponRef.GetComponent<ThisWeaponData>().this_Material_Type != 0 && weaponRef.GetComponent<ThisWeaponData>().this_Weapon_Type != 0 && weaponRef.GetComponent<ThisWeaponData>().this_Enchantment_Type != 0)
        {
            weaponenchantedItemCheck = true;
            tickImages[2].SetActive(true);
        }
    }
}
