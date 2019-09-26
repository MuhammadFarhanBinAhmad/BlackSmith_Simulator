using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNewRuneSquareMaster : MonoBehaviour
{
    public List<int> runeSequence = new List<int>();

    public GameObject[] RuneSquareButtonReferenceTest = new GameObject[4];

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
                        Debug.Log(newIncomingNumber + " is already in the list");
                    }
                }

                //Debug.Log("Duplicate number check completed");
            }
            else if (runeSequence.Count == 0)
            {
                duplicateNumber = false;
            }

            if (duplicateNumber == false)
            {
                Debug.Log("Duplicate number check completed. Adding " + newIncomingNumber + " to the list");
                runeSequence.Add(newIncomingNumber);

                if (runeSequence.Count == 4)
                {
                    //spawn rune function
                    Debug.Log("List completed, now checking for possible sequence");
                    TestFunction();
                }

            }
        }
    }


    public void TestFunction()
    {
        //Sequence check 1
        if (runeSequence[0] == 1 && runeSequence[1] ==2 & runeSequence[2] == 3 && runeSequence[3] == 4)
        {
            Debug.Log("RuneSequence is the same as sequence 1");
            ResetRuneSpawner();
        }
        //Sequence check 2
        else if (runeSequence[0] == 1 && runeSequence[1] == 3 & runeSequence[2] == 4 && runeSequence[3] == 2)
        {
            Debug.Log("RuneSequence is the same as sequence 2");
            ResetRuneSpawner();
        }
        //Sequence check 3
        else if (runeSequence[0] == 1 && runeSequence[1] == 4 & runeSequence[2] == 2 && runeSequence[3] == 3)
        {
            Debug.Log("RuneSequence is the same as sequence 3");
            ResetRuneSpawner();
        } 
        //Sequence check 4
        else if (runeSequence[0] == 3 && runeSequence[1] == 2 & runeSequence[2] == 1 && runeSequence[3] == 4)
        {
            Debug.Log("RuneSequence is the same as sequence 4");
            ResetRuneSpawner();
        } 
        //Sequence check 5
        else if (runeSequence[0] == 4 && runeSequence[1] == 1 & runeSequence[2] == 2 && runeSequence[3] == 3)
        {
            Debug.Log("RuneSequence is the same as sequence 5");
            ResetRuneSpawner();
        } 
        //Sequence check 6
        else if (runeSequence[0] == 3 && runeSequence[1] == 4 & runeSequence[2] == 1 && runeSequence[3] == 2)
        {
            Debug.Log("RuneSequence is the same as sequence 6");
            ResetRuneSpawner();
        }  
        //Sequence check 7
        else if (runeSequence[0] == 2 && runeSequence[1] == 3 & runeSequence[2] == 1 && runeSequence[3] == 4)
        {
            Debug.Log("RuneSequence is the same as sequence 7");
            ResetRuneSpawner();
        }
        


    }

    public void ResetRuneSpawner()
    {
        runeSequence.Clear();
        
        for (int i = 0; i < RuneSquareButtonReferenceTest.Length; i++)
        {
            RuneSquareButtonReferenceTest[i].GetComponent<TestNewRuneSquareButton>().ReleaseButton();
        }
    }

}
