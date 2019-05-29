using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRecognition : MonoBehaviour
{
    public List<int> code_Number = new List<int>();//hold the number pattern
    public int number_Receive;//the number this is receive
    public int numbers_In_Code;//count how many numbers are there in the list;

    public GameObject[] baseRuneToSpawn;

    public void NumberHolder()
    {
        if (numbers_In_Code <= 4)//set limit on how many number can be in the list
        {
            bool duplicateNumber = false;

            for (int i = 0; i < code_Number.Count; i++)
            {
                //if the number receive is the same as what it has currently, it will add that number to the list
                if (code_Number[i] == number_Receive)
                {
                    duplicateNumber = true;
                }
            }
            if (!duplicateNumber)
            {
                code_Number.Add(number_Receive);//Add the number receive in List
                number_Receive = 0;//reset number receive
                numbers_In_Code++;
                if (numbers_In_Code == 4)
                {
                    FormulaSheet();//call formula sheet
                }
            }
            else
            {
                duplicateNumber = false;
            }
        }
    }
    //Formula sheet to spawn runes
    public void FormulaSheet()
    {
       
        if (code_Number[0] == 1 && code_Number[1] == 2 && code_Number[2] == 3 && code_Number[3] == 4)
        {
            SpawnBaseRune(1);
        }
        if (code_Number[0] == 1 && code_Number[1] == 3 && code_Number[2] == 4 && code_Number[3] == 2)
        {
            SpawnBaseRune(2);
        }
        if (code_Number[0] == 1 && code_Number[1] == 4 && code_Number[2] == 2 && code_Number[3] == 3)
        {
            SpawnBaseRune(3);
        }
        if (code_Number[0] == 3 && code_Number[1] == 2 && code_Number[2] == 1 && code_Number[3] == 4)
        {
            SpawnBaseRune(4);
        }
        if (code_Number[0] == 4 && code_Number[1] == 1 && code_Number[2] == 2 && code_Number[3] == 3)
        {
            SpawnBaseRune(5);
        }
        if (code_Number[0] == 3 && code_Number[1] == 4 && code_Number[2] == 1 && code_Number[3] == 2)
        {
            SpawnBaseRune(6);
        }
        if (code_Number[0] == 2 && code_Number[1] == 3 && code_Number[2] == 1 && code_Number[3] == 1)
        {
            SpawnBaseRune(7);
        }
        //reset data
        code_Number.Clear();
        numbers_In_Code = 0;
        StartCoroutine(ResetFeedback());
    }

    public void SpawnBaseRune(int baseToSpawnNumber)
    {
        print("Spawning " + baseToSpawnNumber);
        Instantiate(baseRuneToSpawn[baseToSpawnNumber], this.transform.position, this.transform.rotation);
    }


    IEnumerator ResetFeedback()
    {
        GameObject cube = GameObject.Find("Cube (4)");
        Material ogMaterial = cube.GetComponent<MeshRenderer>().material;
        cube.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.5f);
        cube.GetComponent<MeshRenderer>().material.color = new Color(255, 255, 255);
    }
}