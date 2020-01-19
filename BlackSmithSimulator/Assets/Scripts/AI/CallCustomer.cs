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
            bell_Ringing.Play();
        }
    }

    public void BellRing()
    {
        if (current_Scene.name == "Game_Level")
        {
            if (CustomerSpawner.Customer_Already_Serve == 3)
            {
                FindObjectOfType<CustomerSpawner>().NextDay();
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("EndOfDay");
                asyncLoad.allowSceneActivation = false;
                while (!asyncLoad.isDone)
                {
                    if (asyncLoad.isDone)
                    {
                        FindObjectOfType<GameManager>().AddDay();
                        asyncLoad.allowSceneActivation = true;
                    }
                }
            }
            else
            {
                if (FindObjectOfType<CustomerAI>() != null)
                {
                    FindObjectOfType<CustomerAI>().CollectingWeapon();//customer collect weapon
                }
            }
        }
        else if (current_Scene.name == "Tutorial_Level")
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game_Level");
            asyncLoad.allowSceneActivation = false;
            while (!asyncLoad.isDone)
            {
                if (asyncLoad.isDone)
                {
                    FindObjectOfType<GameManager>().AddDay();
                    asyncLoad.allowSceneActivation = true;
                }
            }
        }
        bell_Ringing.Play();
    }
}
