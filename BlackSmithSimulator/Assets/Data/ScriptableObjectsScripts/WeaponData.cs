using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/WeaponData")]
public class WeaponData : ScriptableObject
{
    public int weapon_Material;
    public int weapon_Type;
    public int weapon_Enchantment;

    public GameObject broken_Weapon;

    public List<AudioClip> customer_Dialouge_Speech = new List<AudioClip>();    
}
