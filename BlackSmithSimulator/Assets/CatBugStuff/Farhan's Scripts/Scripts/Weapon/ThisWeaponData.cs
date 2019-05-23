using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisWeaponData : MonoBehaviour
{
    //attach Scriptable object
    public WeaponData the_Weapon_Data;
    //this object data
    public int this_Weapon_Type;
    public int this_Material_Type;
    public int this_Enchantment_Type;

    // Start is called before the first frame update
    void Start()
    {
        this_Weapon_Type = the_Weapon_Data.weapon_Type;//Weapon type
        this_Material_Type = the_Weapon_Data.weapon_Material;//Weapon material
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RuneData>() != null)
        {
            if (other.GetComponent<RuneData>().enchantment_Type != 0)
            {
                this_Enchantment_Type = other.GetComponent<RuneData>().enchantment_Type;
                print("Enchanting with enchantment type" + this_Enchantment_Type);
            }
        }
    }


}
