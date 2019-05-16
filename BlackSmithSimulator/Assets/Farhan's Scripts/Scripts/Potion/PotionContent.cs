using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionContent : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon")
        {
            other.GetComponent<ThisWeaponData>().this_Enchantment_Percentage++;
            Destroy(this.gameObject);
            print("HIt");
        }
    }
}
