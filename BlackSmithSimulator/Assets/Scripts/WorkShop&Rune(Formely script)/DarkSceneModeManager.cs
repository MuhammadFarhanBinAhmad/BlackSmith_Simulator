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

    public IEnumerator LevelToLoad(string levelToLoad)
    {
        /*
        Debug.Log("Loading " + levelToLoad);
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Pause_Main_Menu");
        */
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(levelToLoad);
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
