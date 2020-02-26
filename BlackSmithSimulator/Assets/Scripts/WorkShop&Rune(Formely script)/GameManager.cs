using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager gameManager;
    public static int counterDay = 0;
    public static int counterCustomer = 0;
    public static int scoreKnight = 4;
    public static int scoreDrow = 4;
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
        CheckDay();
    }
    public void AddDay()
    {
        counterDay++;
    }
    void CheckDay()
    {
        if (counterDay == 4)
        {
            SpawnNote();
        }
    }
    
    void SpawnNote()
    {
        if (scoreKnight == 4 && scoreDrow == 4)
        {
            Instantiate(antoine_Customer_Notes[0], note_Spawning_Point[0].transform.position, note_Spawning_Point[0].transform.rotation);
            Instantiate(solana_Customer_Notes[0], note_Spawning_Point[1].transform.position, note_Spawning_Point[1].transform.rotation);
        }
        else if (scoreKnight != 4 && scoreDrow != 4)
        {
            //knight score higher
            if (scoreKnight > scoreDrow)
            {
                Instantiate(antoine_Customer_Notes[1], note_Spawning_Point[0].transform.position, note_Spawning_Point[0].transform.rotation);
                Instantiate(solana_Customer_Notes[1], note_Spawning_Point[1].transform.position, note_Spawning_Point[1].transform.rotation);
            }
            else if (scoreKnight == 0 && scoreDrow == 0)
            {
                Instantiate(antoine_Customer_Notes[3], note_Spawning_Point[0].transform.position, note_Spawning_Point[0].transform.rotation);
                Instantiate(solana_Customer_Notes[3], note_Spawning_Point[1].transform.position, note_Spawning_Point[1].transform.rotation);
            }
            //drow score higher
            else if (scoreDrow > scoreKnight || scoreDrow == scoreKnight)
            {
                Instantiate(antoine_Customer_Notes[2], note_Spawning_Point[0].transform.position, note_Spawning_Point[0].transform.rotation);
                Instantiate(solana_Customer_Notes[2], note_Spawning_Point[1].transform.position, note_Spawning_Point[1].transform.rotation);
            }
        }
        ResetPoint();
    }

    void ResetPoint()
    {
        print("reset");
        GameManager.counterDay = 0;
        scoreKnight = 0;
        scoreDrow = 0;
    }

}
