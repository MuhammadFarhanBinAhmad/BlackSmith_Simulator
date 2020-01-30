using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneData : MonoBehaviour
{

    public RuneDispenserStationData the_Rune_Dispenser_Station_Data;
    public int weapon_Type;
    public int material_Type;
    public int enchantment_Type;

    public RuneMaker runeMakerRef;
    // Start is called before the first frame update
    void Start()
    {
        weapon_Type = the_Rune_Dispenser_Station_Data.type_Weapon_Data;
        material_Type = the_Rune_Dispenser_Station_Data.type_Material_Data;
        enchantment_Type = the_Rune_Dispenser_Station_Data.type_Enchantment_Data;
    }

    public void OnRunePickup()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        if (runeMakerRef != null)
        {
            runeMakerRef.OnPickUpRuneMixer();
            runeMakerRef = null;
        }
    }
}
