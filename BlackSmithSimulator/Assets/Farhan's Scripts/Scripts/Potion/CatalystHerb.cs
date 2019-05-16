using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatalystHerb : MonoBehaviour
{
    public PotionMakingStationData the_Potion_Making_Station_Data;
    public int this_Object_Herb;
    public int this_Object_Catalyst;
    private void Start()
    {
        this_Object_Catalyst = the_Potion_Making_Station_Data.potion_Catalyst;
        this_Object_Herb = the_Potion_Making_Station_Data.potion_Herb;
    }
}
