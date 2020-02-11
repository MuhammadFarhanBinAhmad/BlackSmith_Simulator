using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DarkSceneModeManager : MonoBehaviour
{

    public void Awake()
    {
        Tutorial();
    }
 
    void Tutorial()
    {
        //initialise all tutorial
        FindObjectOfType<TutorialManager>().Tutorial1();

    }

    public IEnumerator LevelToLoad(string levelToLoad)
    {
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
