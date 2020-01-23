using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheats : MonoBehaviour
{
    public string LevelToLoad;

    void update()
    {
        print("able");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameManager.counterDay++;
            Debug.Log("Current day is " + GameManager.counterDay);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(LevelToLoad);
        }
    }
}
