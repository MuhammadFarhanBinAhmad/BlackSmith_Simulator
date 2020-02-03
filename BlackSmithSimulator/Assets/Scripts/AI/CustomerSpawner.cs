using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CustomerSpawner : MonoBehaviour
{

    public static int Customer_Already_Serve;

    public Transform[] destPointsOfInterest;
    public Transform destCounter;
    public Transform destExit;
    public List<GameObject> Customer = new List<GameObject>();

    public GameObject bell_Sparkle;

    WeaponCollectionPoint the_Weapon_Collection_Point;

    public List<string> general_Customer_Anim;
    
    // Start is called before the first frame update
    void Start()
    {
        Customer_Already_Serve = 0;

        the_Weapon_Collection_Point = FindObjectOfType<WeaponCollectionPoint>();
        if(Customer_Already_Serve <= Customer.Count)
        {
            StartCoroutine("SpawnNextCustomer");
        }
    }
    //Spawn Customer
    public void NextDay()
    {
        FindObjectOfType<GameManager>().AddDay();
    }
    public IEnumerator SpawnNextCustomer()
    {

        the_Weapon_Collection_Point.ready_For_Collection = false;
        //wait before next customer spawn
        yield return new WaitForSeconds(3);
        if (Customer_Already_Serve == 2)
        {
            Instantiate(bell_Sparkle, FindObjectOfType<CallCustomer>().transform.position, FindObjectOfType<CallCustomer>().transform.rotation);
            print("hit");
        }
        if (Customer_Already_Serve <= Customer.Count - 1)
        {
            {
                Instantiate(Customer[Customer_Already_Serve], transform.position, Quaternion.identity);
            }
        }
    }
}
