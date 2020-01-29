using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CustomerSpawner : MonoBehaviour
{

    public static int current_day;
    public static int Customer_Already_Serve;

    public Transform[] destPointsOfInterest;
    public Transform destCounter;
    public Transform destExit;
    public List<GameObject> Customer = new List<GameObject>();
    public List<GameObject> brokenWeapon = new List<GameObject>();

    WeaponCollectionPoint the_Weapon_Collection_Point;

    public List<string> general_Customer_Anim;
    
    // Start is called before the first frame update
    void Start()
    {
        print("CurrentDay "+ current_day);
        print("Customer already serve " + Customer_Already_Serve);

        the_Weapon_Collection_Point = FindObjectOfType<WeaponCollectionPoint>();
        if(Customer_Already_Serve < 2)
        {
            StartCoroutine("SpawnNextCustomer");
        }
    }
    //Spawn Customer
    public void NextDay()
    {
        current_day++;
        Customer_Already_Serve = 0;
    }
    public IEnumerator SpawnNextCustomer()
    {
        the_Weapon_Collection_Point.ready_For_Collection = false;
        //wait before next customer spawn
        yield return new WaitForSeconds(3);
        if (Customer_Already_Serve < 3)
        {
            {
                Instantiate(Customer[Customer_Already_Serve], transform.position, Quaternion.identity);
            }
        }
    }
}
