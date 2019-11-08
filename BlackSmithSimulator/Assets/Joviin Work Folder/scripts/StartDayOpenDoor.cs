using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK.Controllables;
using UnityEngine.UI;

public class StartDayOpenDoor : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public Text displayText;
    public string outputOnMax = "Maximum Reached";
    public string outputOnMin = "Minimum Reached";
    Scene current_Scene;

    private void Start()
    {
        current_Scene = SceneManager.GetActiveScene();
    }

    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {

    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
 
        if (current_Scene.name == "EndOfDay")
        {
            SceneManager.LoadScene("Pause_Main_Menu");
        }

    }
    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (current_Scene.name == "Pause_Main_Menu")
        {
            SceneManager.LoadScene("Game_Level");
        }
    }
}

