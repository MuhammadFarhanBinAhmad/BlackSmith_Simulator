using UnityEngine;
using UnityEngine.SceneManagement;

public class CallCustomer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Controller (right)" || other.name == "Controller (left)" || other.name == "Cube")
        {
            if (CustomerSpawner.Customer_Already_Serve == 3)
            {
                SceneManager.LoadScene("EndOfDay");
            }
            else
            {
                if (FindObjectOfType<CustomerAI>() != null)
                {
                    FindObjectOfType<CustomerAI>().CollectingWeapon();//customer collect weapon
                }
            }
        }
    }
}
