using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurVillInput : MonoBehaviour
{
    public int type_Material_Rune;
    public int type_Weapon_Rune;
    public FunVillStationData the_FunVill_Station_Data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RunesMaterial")
        {

        }

    }
}
