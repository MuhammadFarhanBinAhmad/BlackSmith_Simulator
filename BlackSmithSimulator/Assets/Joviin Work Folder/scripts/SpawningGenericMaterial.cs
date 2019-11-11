using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningGenericMaterial : MonoBehaviour
{
    public GameObject GenericMaterialPrefab;

    public void SpawnGMaterial()
    {
        Instantiate(GenericMaterialPrefab);
    }
}
