using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderScript : MonoBehaviour
{
    //To be attached to AI spawner(above the counter)

    public GameObject[] weaponBroken;
    public int[] numberToGive;


    private void Start()
    {
        GiveWeapon(numberToGive[0]);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If (other.getComponent<Weapon>() != null)
    }

    void GiveWeapon(int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            Instantiate(weaponBroken[0], this.transform.position, this.transform.rotation);
        }
 
    }

    void RecieveWeapon()
    {

    }
}
