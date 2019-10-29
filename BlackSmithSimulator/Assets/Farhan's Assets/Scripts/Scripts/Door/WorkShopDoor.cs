using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WorkShopDoor : MonoBehaviour
{
    public List<string> scene_Name = new List<string>();

    private void Start()
    {
        scene_Name.Add("GameLevel");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StoreOpenBoxCollider")
        {
            SceneManager.LoadScene(scene_Name[0]);//open store
        }
        if (other.name == "StoreCloseBoxCollider")
        {
            FindObjectOfType<CustomerSpawner>().NextDay();
        }
    }
}
