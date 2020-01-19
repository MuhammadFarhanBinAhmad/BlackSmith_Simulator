using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkSceneModeManager : MonoBehaviour
{
    public LevelModeType levelMode;



    public enum LevelModeType
    {
        Null,
        Tutorial,
        LevelLoad
    }
    public void Awake()
    {
        LevelModeSwitch();
    }
    public void LevelModeSwitch()
    {
        switch (levelMode)
        {
            case LevelModeType.Null:
                break;
            case LevelModeType.Tutorial:
                Debug.Log("Starting Tutorial");
                Tutorial();
                break;
            case LevelModeType.LevelLoad:
                StartCoroutine(LevelToLoad("Pause_Main_Menu"));
                break;
        }
    }

    public void LevelModeSwitch(string levelToLoad)
    {
        StartCoroutine(LevelToLoad(levelToLoad));
    }


    void Tutorial()
    {
        //initialise all tutorial
        FindObjectOfType<TutorialManager>().Tutorial1();

    }

    IEnumerator LevelToLoad(string levelToLoad)
    {
        Debug.Log("Loading " + levelToLoad);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);
        asyncLoad.allowSceneActivation = false;
        while (!asyncLoad.isDone)
        {
            if (asyncLoad.isDone)
            {
                yield return new WaitForSecondsRealtime(3f);
                asyncLoad.allowSceneActivation = true;
            }

            yield return null;
        }
    }

}
