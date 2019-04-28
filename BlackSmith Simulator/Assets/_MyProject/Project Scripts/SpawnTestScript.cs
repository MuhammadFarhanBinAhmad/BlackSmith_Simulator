using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTestScript : MonoBehaviour
{
    public GameObject materialToSpawn;
    public List<GameObject> objects = new List<GameObject>();

    void Start()
    {
        for(int i = 0; i  <1; i++)
        {
            GameObject a = Instantiate(materialToSpawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            a.GetComponent<WeaponMaterial>().materialState = 1;
            a.name = "Material" + objects.Count.ToString(); 
            objects.Add(materialToSpawn);  
        }
    }
}
