using UnityEngine;
using UnityEngine.SceneManagement;

public class CallCustomer : MonoBehaviour
{

    public AudioSource bell_Ringing;
    Scene current_Scene;

    private void Start()
    {
        current_Scene = SceneManager.GetActiveScene();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Controller (right)" || other.name == "Controller (left)" || other.name == "Cube")
        {
            if(current_Scene.name == "Game_Level")
            {
                if (DayAndCustomer.Customer_Already_Serve == 3)
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
            bell_Ringing.Play();
        }
    }

    public void BellRing()
    {
        if (current_Scene.name == "Game_Level")
        {
            if (DayAndCustomer.Customer_Already_Serve == 3)
            {
                FindObjectOfType<CustomerSpawner>().NextDay();
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
        bell_Ringing.Play();
    }
}
