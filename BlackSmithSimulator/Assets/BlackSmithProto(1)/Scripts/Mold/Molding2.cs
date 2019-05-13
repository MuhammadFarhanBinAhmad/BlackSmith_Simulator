using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molding2 : MonoBehaviour
{
    public int mold_Prefab;
    private void Start()
    {
        mold_Prefab = 1;
    }
    private void Update()
    {
        if (mold_Prefab == 4)
        {
            mold_Prefab = 1;
        }
    }
    public void ChangePrefab()
    {
        if (mold_Prefab <= 4)
        {
            mold_Prefab++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ore")
        {
           if (mold_Prefab == 1)
            {
                other.transform.localScale = new Vector3(1, 0.5f, 1);
                other.GetComponent<Ore>().current_Weapon_Type = "Dagger";
            }
            if (mold_Prefab == 2)
            {
                other.transform.localScale = new Vector3(1, 2, 1);
                other.GetComponent<Ore>().current_Weapon_Type = "Sword";

            }
            if (mold_Prefab == 3)
            {
                other.transform.localScale = new Vector3(1, 2, 2);
                other.GetComponent<Ore>().current_Weapon_Type = "Hammer";

            }
        }
    }
}
