using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTestScript : MonoBehaviour
{
    public GameObject materialToSpawn;
    public List<GameObject> objects = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i  <10; i++)
        {
            GameObject a = Instantiate(materialToSpawn);
            a.GetComponent<WeaponMaterial>().materialState = 1;
            a.name = "Material" + objects.Count.ToString(); 
            objects.Add(materialToSpawn);  
        }
    }
}
