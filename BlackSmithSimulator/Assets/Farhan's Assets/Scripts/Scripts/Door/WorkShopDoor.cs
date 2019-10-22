using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WorkShopDoor : MonoBehaviour
{
    public List<string> scene_Name = new List<string>();

    private void Start()
    {
        scene_Name.Add("AI Test Menu");
        scene_Name.Add("PauseStore");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StoreOpenBoxCollider")
        {
            SceneManager.LoadScene(scene_Name[0]);//open store
        }
        if (other.name == "StoreCloseBoxCollider")
        {
            if (CustomerSpawner.Customer_Already_Serve <= 2)
            {
                SceneManager.LoadScene(scene_Name[1]);//pause store
            }
            else
            {
                FindObjectOfType<CustomerSpawner>().NextDay();
            }
        }
    }
}
