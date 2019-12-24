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
        LevelModeSwitch(levelMode);
    }
    public void LevelModeSwitch()
    {
        switch (levelMode)
        {
            case LevelModeType.Null:
                break;
        }
    }
    public void LevelModeSwitch(LevelModeType modeType)
    {
        switch (levelMode)
        {
            case LevelModeType.Null:
                break;
            case LevelModeType.Tutorial:
                Tutorial();
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Use a coroutine to load the Scene in the background
            LevelModeSwitch("Pause_Main_Menu");
        }
    }
    */
}
