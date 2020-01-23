using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager gameManager;
    public static int counterDay = 0;
    public static int counterCustomer = 0;
    public static int scoreKnight = 0;
    public static int scoreDrow = 0;

    private void Awake()
    {
        //Always force one instance of this object;
        DontDestroyOnLoad(this.gameObject);
        if(gameManager == null)
        {
            gameManager = this.GetComponent<GameManager>();
        }
        else 
        {
            Destroy(this.gameObject);
        }

        Debug.Log("Current Day defined by the Game Manager is " + counterDay);
    }

    public void AddDay()
    {
        counterDay++;
        Debug.Log("Current Day defined by the Game Manager is " + counterDay);
    }

}
