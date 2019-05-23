using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternRecognition : MonoBehaviour
{
    public List<int> code_Number = new List<int>();//hold the number pattern
    public int number_Receive;//the number this is receive
    public int numbers_In_Code;//count how many numbers are there in the list;

    public void NumberHolder()
    {
        if (numbers_In_Code <= 5)//set limit on how many number can be in the list
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
                if (numbers_In_Code == 6)
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
        if (code_Number[0] == 1 && code_Number[1] == 2 && code_Number[2] == 3 && code_Number[3] == 4 && code_Number[4] == 5 && code_Number[5] == 6)
        {
            print("BaseRune1");
        }
        if (code_Number[0] == 3 && code_Number[1] == 5 && code_Number[2] == 7 && code_Number[3] == 4 && code_Number[4] == 1 && code_Number[5] == 2)
        {
            print("BaseRune2");
        }
        if (code_Number[0] == 1 && code_Number[1] == 4 && code_Number[2] == 2 && code_Number[3] == 6 && code_Number[4] == 5 && code_Number[5] == 8)
        {
            print("BaseRune3");
        }
        if (code_Number[0] == 2 && code_Number[1] == 4 && code_Number[2] == 5 && code_Number[3] == 3 && code_Number[4] == 6 && code_Number[5] == 9)
        {
            print("BaseRune4");
        }
        if (code_Number[0] == 2 && code_Number[1] == 1 && code_Number[2] == 4 && code_Number[3] == 8 && code_Number[4] == 6 && code_Number[5] == 9)
        {
            print("BaseRune5");
        }
        if (code_Number[0] == 3 && code_Number[1] == 5 && code_Number[2] == 7 && code_Number[3] == 8 && code_Number[4] == 9 && code_Number[5] == 6)
        {
            print("BaseRune6");
        }
        if (code_Number[0] == 4 && code_Number[1] == 2 && code_Number[2] == 3 && code_Number[3] == 6 && code_Number[4] == 9 && code_Number[5] == 8)
        {
            print("BaseRune7");
        }
        //reset data
        code_Number.Clear();
        numbers_In_Code = 0;
    }
}