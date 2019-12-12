using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndCustomer : MonoBehaviour
{

    public static int current_day = 5;
    public static int Customer_Already_Serve;

    public List<GameObject> customer_Notes = new List<GameObject>();
    public List<GameObject> note_Spawning_Point = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //print("play");
        if (current_day == 5)
        {
            //print("hit");
            for (int i = 0; i < customer_Notes.Count; i++)
            {
                Instantiate(customer_Notes[i], note_Spawning_Point[i].transform.position, note_Spawning_Point[i].transform.rotation);
            }
            current_day = 0;
            print(current_day);
        }
    }

}
