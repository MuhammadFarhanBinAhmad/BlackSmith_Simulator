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
            if(current_Scene.name == "GameLevel")
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
            if (current_Scene.name == "EndOfDay")
            {
                SceneManager.LoadScene("Pause_Main_Menu");
            }
            if (current_Scene.name == "Pause_Main_Menu")
            {
                SceneManager.LoadScene("GameLevel");
            }
            bell_Ringing.Play();
        }
    }
}
