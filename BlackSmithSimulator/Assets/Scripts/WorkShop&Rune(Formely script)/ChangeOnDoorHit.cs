using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeOnDoorHit : MonoBehaviour
{
    public bool OnDoorClose;
    bool allowSceneChange = false;

    private void Start()
    {
        Invoke("AllowSceneChange", 3f);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "DoorObject" && allowSceneChange == true)
        {
            ChangeScene();
        }
    }

    public void ChangeScene()
    {
        if (OnDoorClose == true)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Pause_Main_Menu");
            asyncLoad.allowSceneActivation = false;
            while (!asyncLoad.isDone)
            {
                if (asyncLoad.isDone)
                {
                    asyncLoad.allowSceneActivation = true;
                }
            }
        }

        else if(OnDoorClose == false)
        {
            if (GameManager.counterDay == 0)
            {
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Tutorial_Level");
                asyncLoad.allowSceneActivation = false;
                while (!asyncLoad.isDone)
                {
                    if (asyncLoad.isDone)
                    {
                        asyncLoad.allowSceneActivation = true;
                    }
                }
            }
            else if (GameManager.counterDay > 0)
            {
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game_Level");
                asyncLoad.allowSceneActivation = false;
                while (!asyncLoad.isDone)
                {
                    if (asyncLoad.isDone)
                    {
                        asyncLoad.allowSceneActivation = true;
                    }
                }
            }
        }
    }

    private void AllowSceneChange()
    {
        Debug.Log("Allow Scene Change Now");
        allowSceneChange = true;
    }
    
}
