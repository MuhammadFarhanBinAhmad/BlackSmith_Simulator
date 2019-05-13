﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanvilTest : MonoBehaviour
{
    public List<GameObject> materialCollected = new List<GameObject>();
    public int materialType;

    //Output material
    public int weaponType;
    public MeshFilter[] weaponTypeModels;
    public Material[] weaponTypeMaterials;


    private void Start()
    {
        materialCollected.Clear();
        materialType = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ore>() != null)
        {
            for (int i = 0; i <materialCollected.Count; i++)
            {
                if (materialCollected[i] == other.gameObject)
                {
                    materialCollected.Clear();
                    materialType = 0;
                    print("Materials already collected");
                    break;
                }
            }
            materialCollected.Add(other.gameObject);
            materialType = materialCollected[0].GetComponent<Ore>().material_Ore;
        }
        if (other.tag == "FanvilBase")
        {
            print("Material Check Starting");
            CheckMaterials();
        }

    }

    public void CheckMaterials()
    {
        int materialTypeLocal = materialType;
        for (int i = 0; i < materialCollected.Count; i++)
        {
           if  (materialCollected[i].GetComponent<Ore>().material_Ore != materialTypeLocal)
            {
                materialCollected.Clear();
                materialType = 0;
                print("Only one material at a time ");
                break;
            }
            else
            {


            }
        }

        if (materialCollected.Count != 0)
        {
            CreateWeapon(weaponType);
        }

    }

    public void CreateWeapon(int weaponTypeLocal)
    {
        print("CreatingWeapon");
        materialCollected[0].GetComponent<MeshFilter>().sharedMesh = weaponTypeModels[weaponType].sharedMesh;
        print(materialCollected[0].GetComponent<Mesh>());
        print("Mesh Change Successful!");
        materialCollected[0].GetComponent<MeshRenderer>().material = weaponTypeMaterials[weaponType];
        print("Material Change Successful!");
        materialCollected[0].GetComponent<Ore>().thisWeaponType = weaponTypeLocal;
        materialCollected.RemoveAt(0);
        for (int i = 0; i < materialCollected.Count; i++)
        {
            GameObject.Destroy(materialCollected[i]);
            materialCollected.Clear();
        }
    }
}