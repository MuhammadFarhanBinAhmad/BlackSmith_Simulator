using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanvil : MonoBehaviour
{
    //Input material
    public List<GameObject> materialCollected = new List<GameObject>();

    //Runes
    public GameObject runeWeapon;
    public GameObject runeMaterial;
    public int materialTypeRune;

    //Output material
    public int weaponTypeRune;
    public GameObject[] weaponTypeModels;
    public Material[] weaponTypeMaterials;

    private void Start()
    {
        //clear all data collected
        materialCollected.Clear();
        materialTypeRune = 0;
    }

    public void OnTriggerEnter(Collider other)
    {

        //Detect or as Fanvil goes down
        if (other.GetComponent<BrokenWeapon>() != null)
        {
            for (int i = 0; i <materialCollected.Count; i++)
            {
                if (materialCollected[i] == other.gameObject)
                {
                    materialCollected.Clear();
                    //materialTypeCollected = 0;
                    print("Materials already collected");
                    break;
                }
            }
            materialCollected.Add(other.gameObject);
        }

        //Check materials gathered when hit the base
        if (other.tag == "FanvilBase")
        {
            print("Material Check Starting");
            CheckMaterials();
        }

        //Take in inputs from Runes
        

          if(other.GetComponent<RuneData>() !=null)
          {
            if (other.GetComponent<RuneData>().weapon_Type != 0)
            {
                runeWeapon = other.gameObject;
                weaponTypeRune = other.GetComponent<RuneData>().weapon_Type;
            }

            if (other.GetComponent<RuneData>().material_Type != 0)
            {
                runeMaterial = other.gameObject;
                materialTypeRune = other.GetComponent<RuneData>().material_Type;
            }       
          }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RuneData>() != null)
        {
            if (other.GetComponent<RuneData>().weapon_Type != 0)
            {
                runeWeapon = null;
                print(other.name + " Removed");
            }

            if (other.GetComponent<RuneData>().material_Type != 0)
            {
                runeMaterial = null;
                print(other.name + " Removed");
            }
        }
    }

    public void CheckMaterials()
    {       
        if (weaponTypeRune != 0 && materialTypeRune != 0)
        {

            //Second Check if Material Rune matches material or material used is a universal material
            if (materialCollected.Count != 0)
            {
                print("Universal material detected, using Rune as base material now");
                CreateWeapon(weaponTypeRune, materialTypeRune);

            }
        }

    }

    //If Generic material is used
    public void CreateWeapon(int weaponTypeLocal, int materialTypeLocal)
    {
        print("Creating Weapon" + weaponTypeLocal + " With " + materialTypeLocal + "material as base");
        GameObject newWeapon;
        newWeapon = Instantiate(weaponTypeModels[weaponTypeLocal], this.transform.position, Quaternion.Euler(90, 0, 0));

        newWeapon.GetComponent<MeshRenderer>().material = weaponTypeMaterials[materialTypeLocal];
        print("Material Change Successful!");

        newWeapon.GetComponent<ThisWeaponData>().this_Material_Type = materialTypeRune;
        for (int i = 0; i < materialCollected.Count; i++)
        {
            print("Destroying item " + i);
            GameObject.Destroy(materialCollected[i]);
            materialCollected.Clear();
        }

        GameObject.Destroy(runeWeapon);
        GameObject.Destroy(runeMaterial);
        runeWeapon = null;
        runeMaterial = null;
        print("Destroyed weapons and reseting Fanvil");

        materialTypeRune = 0;
        weaponTypeRune = 0;
    }
}