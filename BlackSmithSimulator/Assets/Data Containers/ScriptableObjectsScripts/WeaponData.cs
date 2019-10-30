using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/WeaponData")]
public class WeaponData : ScriptableObject
{
    public int weapon_Material;
    public int weapon_Type;
    public int weapon_Enchantment;

    public List<AudioSource> customer_Order_Speech = new List<AudioSource>();
    public List<AudioSource> customer_Idel_Chatting = new List<AudioSource>();
}
