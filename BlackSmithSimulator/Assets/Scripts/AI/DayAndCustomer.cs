using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndCustomer : MonoBehaviour
{

    //public List<GameObject> customer_Notes = new List<GameObject>();
    //public List<GameObject> note_Spawning_Point = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //print("play");
        if (GameManager.counterDay == 4)
        {
            //print("hit");
            /*for (int i = 0; i < customer_Notes.Count; i++)
            {
                Instantiate(customer_Notes[i], note_Spawning_Point[i].transform.position, note_Spawning_Point[i].transform.rotation);
            }*/
            GameManager.counterDay = 0;
        }
    }

}
