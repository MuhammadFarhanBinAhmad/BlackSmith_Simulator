using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CustomerSpawner : CustomerPointOfInterest
{

    public static int current_day;
    public static int Customer_Already_Serve;

    public GameObject the_Sun;
    public List<GameObject> Customer = new List<GameObject>();

    WeaponCollectionPoint the_Weapon_Collection_Point;

    public List<string> general_Customer_Anim;
    
    // Start is called before the first frame update
    void Start()
    {
        print(current_day + "CurrentDay");
        print(Customer_Already_Serve + "Customer_Already_Serve");

        the_Weapon_Collection_Point = FindObjectOfType<WeaponCollectionPoint>();
        if(Customer_Already_Serve == 0)
        {
            StartCoroutine("SpawnNextCustomer");
        }
    }
    //Spawn Customer
    public void NextDay()
    {
        current_day++;
        Customer_Already_Serve = 0;
        SceneManager.LoadScene("Pause_Main_Menu");
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
