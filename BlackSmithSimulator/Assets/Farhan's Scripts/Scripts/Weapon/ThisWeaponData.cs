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
    //enchantment percentage
    public int this_Enchantment_Percentage;
    public bool is_Enchanted;

    // Start is called before the first frame update
    void Start()
    {
        this_Weapon_Type = the_Weapon_Data.weapon_Type;
        this_Material_Type = the_Weapon_Data.weapon_Material;
        this_Enchantment_Type = the_Weapon_Data.weapon_Enchantment;
        this_Enchantment_Percentage = 0;
    }
    private void FixedUpdate()
    {
        if (this_Enchantment_Percentage >= 100)
        {
            is_Enchanted = true;
            print("True");
        }
    }

}
