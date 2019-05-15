using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/CustomerBrokenWeaponData")]
public class CustomerBrokenWeaponData : ScriptableObject
{
    public BrokenWeaponData the_Broken_Weapon_Data;
}
[System.Serializable]
public class BrokenWeaponData
{
    public int material_Broken_Weapon;
    public int type_Broken_Weapon;
}
