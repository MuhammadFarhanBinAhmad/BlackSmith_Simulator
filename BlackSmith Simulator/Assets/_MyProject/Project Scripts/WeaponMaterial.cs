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
    int materialWeaponType;
    int materialReheatCount;
    int materialBeatCount;

    public MeshFilter thisMesh;
    public Mesh[] materialModel = new Mesh[6];

    public void Start()
    {
        thisMesh = this.GetComponent<MeshFilter>();
        thisMesh.mesh = this.GetComponent<MeshFilter>().mesh;
        print(thisMesh.mesh);
        
    }
    public void smelting()
    {
        if (materialState == 1)
        {
            thisMesh.mesh = materialModel[1]; //change model
            print(thisMesh.mesh);
            materialState = 2;
        }
    }

    public void melting()
    {
        if (materialState == 2)
        {
            thisMesh.mesh = materialModel[2]; //change model
            print(thisMesh.mesh);
            materialState = 3;
        }
    }

    public void casting(int materialWeaponTypeLocal, int materialHeatAndBeat)
    {
        if (materialState == 3)
        {
        thisMesh.mesh = materialModel[3];
        print(thisMesh.mesh);
        materialState = 4;
        materialWeaponType = materialWeaponTypeLocal;
        materialReheatCount = materialBeatCount = materialHeatAndBeat;
        }
    }

    public void Heating()
    {
        if (materialReheatCount > 0 && materialReheatCount == materialBeatCount)
        {
            //change model
            materialReheatCount -= 1;
        }
        
    }

    public void Beating()
    {
        if (materialBeatCount > 0 && materialReheatCount != materialBeatCount)
        {
            //change model
            materialBeatCount -= 1;
        }

    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<WeaponMaterial>() == null){
            melting();
            smelting();
        }

    }
}
