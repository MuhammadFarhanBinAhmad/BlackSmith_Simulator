using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK.Controllables;
using UnityEngine.UI;

public class StartDayOpenDoor : MonoBehaviour
{
    public bool changeSceneOnDoorOpen;
    public VRTK_BaseControllable controllable;
    public Text displayText;
    public string outputOnMax = "Maximum Reached";
    public string outputOnMin = "Minimum Reached";


    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {
        Debug.Log(e.value);
    }


    //Door Closed
    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        if (changeSceneOnDoorOpen == false)
        {
            SceneManager.LoadScene("Pause_Main_Menu");
        }
    }

    //Door Open
    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
        if (changeSceneOnDoorOpen == true)
        {
            SceneManager.LoadScene("Game_Level");
        }
    }
}

