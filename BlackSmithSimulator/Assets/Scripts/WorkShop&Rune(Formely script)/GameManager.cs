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

    public List<GameObject> solana_Customer_Notes = new List<GameObject>();
    public List<GameObject> antoine_Customer_Notes = new List<GameObject>();
    public List<GameObject> note_Spawning_Point = new List<GameObject>();
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
        if (GameManager.counterDay == 4)
        {
            if (scoreKnight != 4)
            {
                Instantiate(antoine_Customer_Notes[0], note_Spawning_Point[0].transform.position, note_Spawning_Point[0].transform.rotation);
            }
            else
            {
                Instantiate(antoine_Customer_Notes[1], note_Spawning_Point[0].transform.position, note_Spawning_Point[0].transform.rotation);
            }
            if (scoreDrow != 4)
            {
                Instantiate(solana_Customer_Notes[0], note_Spawning_Point[1].transform.position, note_Spawning_Point[1].transform.rotation);
            }
            else
            {
                Instantiate(solana_Customer_Notes[1], note_Spawning_Point[1].transform.position, note_Spawning_Point[1].transform.rotation);
            }
            ResetPoint();
        }
        else
        {
            counterDay++;
        }
        Debug.Log("Current Day defined by the Game Manager is " + counterDay);
    }
    void ResetPoint()
    {
        GameManager.counterDay = 0;
        scoreKnight = 0;
        scoreDrow = 0;
    }

}
