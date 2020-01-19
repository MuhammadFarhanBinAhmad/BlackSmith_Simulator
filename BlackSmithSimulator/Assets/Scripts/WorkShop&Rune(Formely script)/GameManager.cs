using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int counterDay = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Debug.Log("Current Day defined by the Game Manager is " + counterDay);
    }

    public void AddDay()
    {
        counterDay++;
        Debug.Log("Current Day defined by the Game Manager is " + counterDay);
    }
}
