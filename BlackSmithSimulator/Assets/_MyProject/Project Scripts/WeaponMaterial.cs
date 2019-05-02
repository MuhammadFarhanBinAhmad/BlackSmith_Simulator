using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMaterial : MonoBehaviour
{   
    
    WeaponMaterial(int materialValueConstruct, int materialStateConstruct)
    {
        materialValue = materialValueConstruct;
        materialState = materialStateConstruct;
    }

    public int materialValue;
    public int materialState;
    public int materialWeaponType;
    public int materialReheatCount;
    public int materialBeatCount;

    public MeshFilter thisMesh;
    public Mesh[] materialModel;

    public Material[] materials;
    public MeshRenderer thisMaterial;

    public void Start()
    {
        thisMesh = this.GetComponent<MeshFilter>();
        thisMesh.mesh = this.GetComponent<MeshFilter>().mesh;
        thisMesh.mesh = materialModel[materialState];
        print(thisMesh.mesh);

        thisMaterial = this.GetComponent<MeshRenderer>();
        thisMaterial.material = materials[materialState-1];
    }
    public void Smelting()
    {    
        if (materialState == 1)
        {
            materialState = 2;
            thisMesh.mesh = materialModel[materialState]; //change model
            thisMaterial.material = materials[materialState-1];
            print(thisMesh.mesh);
        }
    }

    public void MeltingCasting(int materialWeaponTypeLocal, Mesh materialWeaponMesh)
    {
        if (materialState == 2)
        {
            materialState = 3;
            thisMesh.mesh = materialWeaponMesh; //change model
            thisMaterial.material = materials[materialState - 1];
            print(thisMesh.mesh);
            materialWeaponType = materialWeaponTypeLocal;
            materialReheatCount = materialWeaponTypeLocal + 1;
            materialBeatCount = materialWeaponTypeLocal;
        }
    }

  

    public void Heating()
    {
        if (materialReheatCount > 0 && materialReheatCount != materialBeatCount)
        {
            //change model
            materialReheatCount -= 1;
            thisMaterial.material = materials[3];
        }
        
    }

    public void Beating()
    {
        if (materialBeatCount > 0 && materialReheatCount == materialBeatCount)
        {
            //change model
            materialBeatCount -= 1;
            thisMaterial.material = materials[4];
        }

    }

    public void Tempering()
    {
        if (materialState == 3 && materialReheatCount == 0)
        {
            materialState = 4;
            //thisMesh.mesh = materialModel[materialWeaponType];
            thisMaterial.material = materials[materialState + 1];
        }
    }

}
