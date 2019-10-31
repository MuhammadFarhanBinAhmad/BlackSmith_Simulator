using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WorkShopDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StoreOpenBoxCollider")
        {
            SceneManager.LoadScene("GameLevel");//open store
        }
        if (other.name == "StoreCloseBoxCollider")
        {
            FindObjectOfType<CustomerSpawner>().NextDay();
        }
    }
}
