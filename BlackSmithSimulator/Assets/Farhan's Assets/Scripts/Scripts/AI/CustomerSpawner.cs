using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CustomerSpawner : CustomerPointOfInterest
{

    public GameObject the_Sun;
    public List<GameObject> Customer = new List<GameObject>();

    WeaponCollectionPoint the_Weapon_Collection_Point;

    public List<string> general_Customer_Anim;
    
    // Start is called before the first frame update
    void Start()
    {

        the_Weapon_Collection_Point = FindObjectOfType<WeaponCollectionPoint>();
        if(DayAndCustomer.Customer_Already_Serve < 4)
        {
            StartCoroutine("SpawnNextCustomer");
        }
    }
    //Spawn Customer
    public void NextDay()
    {
        DayAndCustomer.current_day++;
        DayAndCustomer.Customer_Already_Serve = 0;
    }
    public IEnumerator SpawnNextCustomer()
    {
        the_Weapon_Collection_Point.ready_For_Collection = false;
        //wait before next customer spawn
        yield return new WaitForSeconds(3);
        if (DayAndCustomer.Customer_Already_Serve < 3)
        {
            {
                Instantiate(Customer[DayAndCustomer.Customer_Already_Serve], transform.position, Quaternion.identity);
            }
        }
    }
}
