using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fanvil : MonoBehaviour
{
    //Input material
    public List<GameObject> materialCollected = new List<GameObject>();
    public int materialTypeCollected;
    public int materialTypeRune;

    //Output material
    public int weaponType;
    public MeshFilter[] weaponTypeModels;
    public Material[] weaponTypeMaterials;


    private void Start()
    {
        //clear all data collected
        materialCollected.Clear();
        materialTypeCollected = 0;
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
                    materialTypeCollected = 0;
                    print("Materials already collected");
                    break;
                }
            }
            materialCollected.Add(other.gameObject);
            materialTypeCollected = materialCollected[0].GetComponent<BrokenWeapon>().material_Ore;
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
            weaponType = other.GetComponent<RuneData>().weapon_Type;
            materialTypeRune = other.GetComponent<RuneData>().material_Type;
               
          }
          
    }

    public void CheckMaterials()
    {
        
        //First Check that materials are all same before fixing weapon
        int materialTypeLocal = materialTypeCollected;
        for (int i = 0; i < materialCollected.Count; i++)
        {
           if  (materialCollected[i].GetComponent<BrokenWeapon>().material_Ore != materialTypeLocal)
            {
                materialCollected.Clear();
                materialTypeCollected = 0;
                print("Only one material at a time ");
                break;
            }
            else
            {


            }
        }

        //Second Check if Material Rune matches material or material used is a universal material
        if (materialCollected.Count != 0)
        {
            //Material matches material rune and not a universal material
            if (materialTypeCollected == materialTypeRune && materialTypeCollected !=5)
            {
                print("Rune matches Type Collected");
                CreateWeapon(weaponType);
            }
            //Material is a universal material
            else if(materialTypeCollected == 5)
            {
                print("Universal material detected, using Rune as base material now");
                CreateWeapon(weaponType, materialTypeRune);
            }
            //Material does not match material rune and will be converted to universal material
            else
            {
                print("Rune Does not Match type collected");
                CreateWeapon(0);
            }
        }

    }


    //If material from base material is used or creating universal rune
    public void CreateWeapon(int weaponTypeLocal)
    {
        print("Creating Weapon with collected materials as base");

        materialCollected[0].GetComponent<MeshFilter>().sharedMesh = weaponTypeModels[weaponTypeLocal].sharedMesh;

        print("Mesh Change Successful!");

        materialCollected[0].GetComponent<MeshRenderer>().material = weaponTypeMaterials[weaponTypeLocal];
        print("Material Change Successful!");

        materialCollected[0].GetComponent<BrokenWeapon>().thisWeaponType = weaponTypeLocal;
        materialCollected.RemoveAt(0);
        for (int i = 0; i < materialCollected.Count; i++)
        {
            GameObject.Destroy(materialCollected[i]);
            materialCollected.Clear();
        }
        materialTypeRune = 0;
        materialTypeCollected = 0;
        weaponType = 0;
        //destroy weapon rune
        //destroy material rune
    }

    //If universal material is used
    public void CreateWeapon(int weaponTypeLocal, int materialTypeLocal)
    {
        print("Creating Weapon with Rune material as base");

        materialCollected[0].GetComponent<MeshFilter>().sharedMesh = weaponTypeModels[weaponTypeLocal].sharedMesh;
        print("Mesh Change Successful!");

        materialCollected[0].GetComponent<MeshRenderer>().material = weaponTypeMaterials[materialTypeLocal];
        print("Material Change Successful!");

        materialCollected[0].GetComponent<BrokenWeapon>().thisWeaponType = weaponTypeLocal;
        materialCollected.RemoveAt(0);
        for (int i = 0; i < materialCollected.Count; i++)
        {
            GameObject.Destroy(materialCollected[i]);
            materialCollected.Clear();
        }
        materialTypeRune = 0;
        materialTypeCollected = 0;
        weaponType = 0;
        //destroy weapon rune
        //destroy material rune
    }
}