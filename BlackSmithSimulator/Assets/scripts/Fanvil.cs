using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanvil : MonoBehaviour
{

    public GameObject FanvilVFX;
    public AudioSource FanvilSFX;
    public GameObject weaponSpawnLocation;

    //Input material
    private List<GameObject> materialCollected = new List<GameObject>();

    //Runes
    private GameObject runeWeapon;
    private GameObject runeMaterial;
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
                //print(other.name + " Removed");
            }

            if (other.GetComponent<RuneData>().material_Type != 0)
            {
                runeMaterial = null;
                //print(other.name + " Removed");
            }
        }
    }

    public void CheckMaterials()
    {       
        if (weaponTypeRune != 0 && materialTypeRune != 0)
        {
            //Check if there are materials in the fanvil to use
            if (materialCollected.Count != 0)
            {
                //print("Material detected, creating weapon");
                CreateWeapon(weaponTypeRune, materialTypeRune);
            }
        }
        else if( weaponTypeRune == 0 || materialTypeRune == 0)
        {
            //Clearing Fanvil
            for (int i = 0; i < materialCollected.Count; i++)
            {
                //print("Destroying item " + i);
                GameObject.Destroy(materialCollected[i]);
                materialCollected.Clear();
            }
        }
    }

    //If Generic material is used
    public void CreateWeapon(int weaponTypeLocal, int materialTypeLocal)
    {
        int weaponToPrint = 0;
        //Instantiate new weapon
        print("Creating Weapon" + weaponTypeLocal + " With " + materialTypeLocal + " material as base");
            //Calculate the output weapon
            if (weaponTypeLocal == 1 && materialTypeLocal == 1)
            {
                weaponToPrint = 1;
            }
            else if (weaponTypeLocal ==1 && materialTypeLocal ==2)
            {
                weaponToPrint = 2;
            }
            else if (weaponTypeLocal ==1 && materialTypeLocal ==3)
            {
                weaponToPrint = 3;
            }
            else if (weaponTypeLocal ==1 && materialTypeLocal ==4)
            {
                weaponToPrint = 4;
            }
            else if (weaponTypeLocal ==2 && materialTypeLocal ==1)
            {
                weaponToPrint = 5;
            }
            else if (weaponTypeLocal ==2 && materialTypeLocal ==2)
            {
                weaponToPrint = 6;
            }
            else if (weaponTypeLocal ==2 && materialTypeLocal ==3)
            {
                weaponToPrint = 7;
            }
            else if (weaponTypeLocal ==2 && materialTypeLocal ==4)
            {
                weaponToPrint = 8;
            }
            else if (weaponTypeLocal ==3 && materialTypeLocal ==1)
            {
                weaponToPrint = 9;
            }
            else if (weaponTypeLocal ==3 && materialTypeLocal ==2)
            {
                weaponToPrint = 10;
            }
            else if (weaponTypeLocal ==3 && materialTypeLocal ==3)
            {
                weaponToPrint = 11;
            }
            else if (weaponTypeLocal ==3 && materialTypeLocal ==4)
            {
                weaponToPrint = 12;
            }
            else if (weaponTypeLocal ==4 && materialTypeLocal ==1)
            {
                weaponToPrint = 13;
            }
            else if (weaponTypeLocal ==4 && materialTypeLocal ==2)
            {
                weaponToPrint = 14;
            }
            else if (weaponTypeLocal ==4 && materialTypeLocal ==3)
            {
                weaponToPrint = 15;
            }
            else if (weaponTypeLocal ==4 && materialTypeLocal ==4)
            {
                weaponToPrint = 16;
            }
        GameObject newWeapon;
        GameObject smokeEffect;
        newWeapon = Instantiate(weaponTypeModels[weaponToPrint], weaponSpawnLocation.transform.position, Quaternion.Euler(0, 0, 0));
        smokeEffect = Instantiate(FanvilVFX, weaponSpawnLocation.transform.position, Quaternion.Euler(0, 0, 0));

        newWeapon.GetComponent<MeshRenderer>().material = weaponTypeMaterials[materialTypeLocal];
        //print("Material Change Successful!");

        //newWeapon.GetComponent<ThisWeaponData>().this_Material_Type = materialTypeLocal;

        //Clearing Fanvil
        for (int i = 0; i < materialCollected.Count; i++)
        {
            //print("Destroying item " + i);
            GameObject.Destroy(materialCollected[i]);
            materialCollected.Clear();
        }
        GameObject.Destroy(runeWeapon);
        GameObject.Destroy(runeMaterial);
        runeWeapon = null;
        runeMaterial = null;
        //print("Destroyed runes and reseting Fanvil");
        newWeapon = null;
        materialTypeRune = 0;
        weaponTypeRune = 0;
    }
}