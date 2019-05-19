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
    //enchantment percentage and type
    public int this_Enchantment_Percentage;
    public bool is_Enchanted;

    // Start is called before the first frame update
    void Start()
    {
        this_Weapon_Type = the_Weapon_Data.weapon_Type;//Weapon type
        this_Material_Type = the_Weapon_Data.weapon_Material;//Weapon material
        //this_Enchantment_Type = the_Weapon_Data.weapon_Enchantment;
        this_Enchantment_Type = 0;
        this_Enchantment_Percentage = 0;
    }
    private void FixedUpdate()
    {
        //check if fully enchatment
        if (this_Enchantment_Percentage >= 100)
        {
            is_Enchanted = true;
            print("True");
        }
    }

}
