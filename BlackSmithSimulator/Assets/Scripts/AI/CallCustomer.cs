using UnityEngine;
using UnityEngine.SceneManagement;

public class CallCustomer : MonoBehaviour
{

    public AudioSource bell_Ringing;
    Scene current_Scene;
    public bool isTutorialLevel;

    private void Start()
    {
        current_Scene = SceneManager.GetActiveScene();
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Controller (right)" || other.name == "Controller (left)" || other.name == "Cube")
        {
            if (FindObjectOfType<CustomerAI>() != null)
            {
                FindObjectOfType<CustomerAI>().CollectingWeapon();//customer collect weapon
            }
        }
            /*if(current_Scene.name == "Game_Level")
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
            else if(current_Scene.name == "Tutorial_Level")
            {
                SceneManager.LoadScene("Game_Level");
            }
            bell_Ringing.Play();
        }*/
        }
    
    

    public void BellRing()
    {
        if (current_Scene.name == "Game_Level")
        {
            if (CustomerSpawner.Customer_Already_Serve == 2  && current_Scene.name != "Tutorial_Level")
            {
                
                FindObjectOfType<GameManager>().AddDay();
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
        else if (isTutorialLevel == true)
        {
            SceneManager.LoadScene("Game_Level");

        }
        bell_Ringing.Play();
    }
}
