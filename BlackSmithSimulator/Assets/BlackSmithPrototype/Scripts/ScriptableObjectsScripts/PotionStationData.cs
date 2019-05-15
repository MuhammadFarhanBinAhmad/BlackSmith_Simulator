using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/PotionMakingStationData")]
public class PotionMakingStationData : ScriptableObject
{
    public PotionIngredient the_Potion_Ingredient;
}
[System.Serializable]
public class PotionIngredient
{
    public int potion_Catalyst;
    public int potion_Herb;
}
