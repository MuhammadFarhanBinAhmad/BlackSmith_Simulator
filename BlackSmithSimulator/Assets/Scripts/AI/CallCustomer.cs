using System.Collections;
using System.Collections.Generic;
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
            if (FindObjectOfType<TutorialItemCheck>() != null)
            {
                FindObjectOfType<TutorialItemCheck>().WeaponCompletedCheck();
                if (FindObjectOfType<TutorialItemCheck>().weaponenchantedItemCheck == true)
                {
                    SceneManager.LoadScene("Game_Level");
                }
        
                
            }
            else
            {
                SceneManager.LoadScene("Game_Level");
            }


        }
        bell_Ringing.Play();
    }

    IEnumerator LevelLoad(string level)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(level);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            if (asyncOperation.progress >= 0.9f)
            {
                yield return new WaitForSeconds(3f);
                asyncOperation.allowSceneActivation = true;
            }
        }
    }
}
