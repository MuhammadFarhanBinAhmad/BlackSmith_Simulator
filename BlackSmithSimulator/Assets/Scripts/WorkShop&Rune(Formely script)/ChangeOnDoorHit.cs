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
            SceneManager.LoadScene("Pause_Main_Menu");
        }

        else if(OnDoorClose == false)
        {
            SceneManager.LoadScene("Game_Level");
        }
    }

    private void AllowSceneChange()
    {
        Debug.Log("Allow Scene Change Now");
        allowSceneChange = true;
    }
    
}
