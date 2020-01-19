using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewRuneSquareMaster : MonoBehaviour
{
    public RuneSquareLineRenderer LineRenderer;

    public List<int> runeSequence = new List<int>();

    public GameObject[] RuneSquareButtonReference = new GameObject[4];

    public GameObject[] baseRuneToSpawn = new GameObject[7];

    public GameObject stone_Circle_Effect;

    public AudioSource spawning_Sound;

    public Transform baseRuneSpawnPos;

    private void Start()
    {
        spawning_Sound = GetComponent<AudioSource>();
    }
    public void NumberSequenceList(int newIncomingNumber)
    {
        if (runeSequence.Count < 4)
        {
            //Debug.Log("Number " + newIncomingNumber + " recieved. Proceeding with duplicate number check");
            //Check for duplicate Numbers
            bool duplicateNumber = false;
            if (runeSequence.Count != 0)
            {

                for (int i = 0; i < runeSequence.Count; i++)
                {
                    if (runeSequence[i] == newIncomingNumber)
                    {
                        duplicateNumber = true;
                        //Debug.Log(newIncomingNumber + " is already in the list");
                    }
                }

                //Debug.Log("Duplicate number check completed");
            }
            else if (runeSequence.Count == 0)
            {
                duplicateNumber = false;
            }

            //Add to sequence
            if (duplicateNumber == false)
            {
                //Debug.Log("Duplicate number check completed. Adding " + newIncomingNumber + " to the list");
                runeSequence.Add(newIncomingNumber);

                if (runeSequence.Count == 4)
                {
                    //spawn rune function
                    //Debug.Log("List completed, now checking for possible sequence");
                    SequenceOutput();
                }

            }
        }
    }


    public void SequenceOutput()
    {
        //Sequence check 1
        if (runeSequence[0] == 1 && runeSequence[1] ==2 & runeSequence[2] == 3 && runeSequence[3] == 4)
        {
            //Debug.Log("RuneSequence is the same as sequence 1");
            if (SceneManager.GetActiveScene().name == "Tutorial_Level" && this.GetComponent<Tutorial2>() != null)
            {
                this.GetComponent<Tutorial2>().TutorialEventSend();
            }
            SpawnBaseRune(0);
            ResetRuneSpawner();
        }
        //Sequence check 2
        else if (runeSequence[0] == 1 && runeSequence[1] == 3 & runeSequence[2] == 4 && runeSequence[3] == 2)
        {
            //Debug.Log("RuneSequence is the same as sequence 2");
            SpawnBaseRune(1);
            ResetRuneSpawner();
        }
        //Sequence check 3
        else if (runeSequence[0] == 1 && runeSequence[1] == 4 & runeSequence[2] == 2 && runeSequence[3] == 3)
        {
            //Debug.Log("RuneSequence is the same as sequence 3");
            SpawnBaseRune(2);
            ResetRuneSpawner();
        } 
        //Sequence check 4
        else if (runeSequence[0] == 3 && runeSequence[1] == 2 & runeSequence[2] == 1 && runeSequence[3] == 4)
        {
            //Debug.Log("RuneSequence is the same as sequence 4");
            SpawnBaseRune(3);
            ResetRuneSpawner();
        } 
        //Sequence check 5
        else if (runeSequence[0] == 4 && runeSequence[1] == 1 & runeSequence[2] == 2 && runeSequence[3] == 3)
        {
            //Debug.Log("RuneSequence is the same as sequence 5");
            SpawnBaseRune(4);
            ResetRuneSpawner();
        } 
        //Sequence check 6
        else if (runeSequence[0] == 3 && runeSequence[1] == 4 & runeSequence[2] == 1 && runeSequence[3] == 2)
        {
            //Debug.Log("RuneSequence is the same as sequence 6");
            SpawnBaseRune(5);
            ResetRuneSpawner();
        }  
        //Sequence check 7
        else if (runeSequence[0] == 2 && runeSequence[1] == 3 & runeSequence[2] == 1 && runeSequence[3] == 4)
        {
            //Debug.Log("RuneSequence is the same as sequence 7");
            SpawnBaseRune(6);
            ResetRuneSpawner();
        }
        else
        {
            //Debug.Log("RuneSequence is not recognised");
            ResetRuneSpawner();
        }       
    }

    public void SpawnBaseRune(int baseToSpawnNumber)
    {
        //print("Spawning " + baseToSpawnNumber);
        if (runeSequence.Count == 4)
        {
            Instantiate(baseRuneToSpawn[baseToSpawnNumber], baseRuneSpawnPos.position, Quaternion.Euler(0, 0, 0));
            if (stone_Circle_Effect != null)
            {
                Instantiate(stone_Circle_Effect, baseRuneSpawnPos.position, Quaternion.Euler(0, 0, 0));
            }
            if (spawning_Sound != null)
            {
                spawning_Sound.Play();
            }
        }
    }

    //Reset Spawner
    public void ResetRuneSpawner()
    {
        runeSequence.Clear();
        for (int i = 0; i < RuneSquareButtonReference.Length; i++)
        {
            RuneSquareButtonReference[i].GetComponent<NewRuneSquareButton>().Invoke("ReleaseButton", 1);
        }
        LineRenderer.Invoke("ClearRuneLine", 1);
    }
}
