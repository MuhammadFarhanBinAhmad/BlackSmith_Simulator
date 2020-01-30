using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningGenericMaterial : MonoBehaviour
{
    public GameObject GenericMaterialPrefab;
    List<GameObject> GenericMaterialNo = new List<GameObject>();
    public Transform materialSpawnPos;
    public void SpawnGMaterial()
    {
        //Debug.Log("Checking GMaterials");
        for (int i = 0; i < GenericMaterialNo.Count; i++)
        {
            if (GenericMaterialNo[i] == null)
            {
                GenericMaterialNo.RemoveAt(i);
            }
        }
        if (GenericMaterialNo.Count < 3)
        {
            Instantiate(GenericMaterialPrefab, materialSpawnPos.position, Quaternion.Euler(0, 0, 0));
        }
    }

    private void Start()
    {
        InvokeRepeating("SpawnGMaterial", 0, 30);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BrokenWeapon>() != null)
        {
            GenericMaterialNo.Add(other.gameObject);
        }
    }


}
