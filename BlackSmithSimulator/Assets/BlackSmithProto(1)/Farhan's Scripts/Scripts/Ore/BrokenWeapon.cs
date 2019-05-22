using UnityEngine.UI;
using UnityEngine;

public class BrokenWeapon : MonoBehaviour
{
    public CustomerBrokenWeaponData the_Customer_Broken_Weapon_Data;
    //get type of material
    public int material_Ore;
    //get type of weapon
    public int thisWeaponType;



    private void Start()
    {
        material_Ore = the_Customer_Broken_Weapon_Data.material_Broken_Weapon;
        thisWeaponType = the_Customer_Broken_Weapon_Data.type_Broken_Weapon;
    }

}
