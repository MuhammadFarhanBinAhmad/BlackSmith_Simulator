using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderScript : MonoBehaviour
{
    //To be attached to AI spawner(above the counter)

    public Text requestedMaterialText;
    public Text requestedWeaponText;
    public Text requestedEnchantmentText;

    int requestedMaterial;
    int requestedWeapon;
    int requestedEnchantment;

    private void Start()
    {
        requestedMaterial = 1;
        requestedWeapon = 1;
        requestedEnchantment = 1;

        requestedMaterialText.text = requestedMaterial.ToString();
        requestedWeaponText.text = requestedWeapon.ToString();
        requestedEnchantmentText.text = requestedEnchantment.ToString();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ThisWeaponData>() != null)
        {
            RecieveWeapon(other.gameObject);
        }
    }

    void GiveWeapon(int numberToSpawn)
    {
        for (int i = 0; i < numberToSpawn; i++)
        {
            //Instantiate(weaponBroken[0], this.transform.position, this.transform.rotation);
        }
    }

    void RecieveWeapon(GameObject weaponCollected)
    {
        ThisWeaponData weaponCollectedTemp = weaponCollected.GetComponent<ThisWeaponData>();
        if (weaponCollectedTemp.this_Material_Type == requestedMaterial &&
            weaponCollectedTemp.this_Weapon_Type == requestedWeapon && 
            weaponCollectedTemp.this_Enchantment_Type == requestedEnchantment)
        {
            //Correct case
            print("Weapon Ok! Moving on to next request");
            Destroy(weaponCollected.gameObject);
            GameObject.Find("Body").GetComponent<Animation>().Play("WalkingOut");
            CreateNewRequest();
        }
        else
        {
            //Wrong case
            print("Wrong weapon");
        }

    }

    void CreateNewRequest()
    {
        GameObject.Find("Body").GetComponent<Animator>().SetBool("PlayNextCustomer", true);
        requestedMaterial = Random.Range(1, 5);
        requestedWeapon = Random.Range(1, 5);
        requestedEnchantment = Random.Range(1, 5);

        //Prototype only
        requestedMaterialText.text = requestedMaterial.ToString();
        requestedWeaponText.text = requestedWeapon.ToString();
        requestedEnchantmentText.text = requestedEnchantment.ToString();
        //GameObject.Find("Body").GetComponent<Animator>().SetBool("PlayNextCustomer", false);
        

    }
}
