using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationsTestScript : MonoBehaviour
{
    public bool smelting;
    public bool meltCasting;
    public int weaponType;
    public Mesh[] materialModel;
    public bool heating;
    public bool beating;
    public bool tempering;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<WeaponMaterial>() != null)
        {
            if (smelting == true)
            {
                other.gameObject.GetComponent<WeaponMaterial>().Smelting();
            }
            
            if (meltCasting == true)
            {
                other.gameObject.GetComponent<WeaponMaterial>().MeltingCasting(weaponType, materialModel[weaponType-1]);
            }

            if (heating == true)
            {
                other.gameObject.GetComponent<WeaponMaterial>().Heating();
            }

            if (beating == true)
            {
                other.gameObject.GetComponent<WeaponMaterial>().Beating();
            }

            if (tempering == true)
            {
                other.gameObject.GetComponent<WeaponMaterial>().Tempering();
            }
        }
    }

}
