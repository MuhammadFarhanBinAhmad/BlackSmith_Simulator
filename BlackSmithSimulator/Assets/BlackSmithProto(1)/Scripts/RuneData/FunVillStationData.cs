using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/FunVillStationData")]
public class FunVillStationData : ScriptableObject
{
    public FunVillRunes the_FunVill_Runes;
}
[System.Serializable]
public class FunVillRunes
{
    public int material_Runes;
    public int weapon_Type_Runes;
}
