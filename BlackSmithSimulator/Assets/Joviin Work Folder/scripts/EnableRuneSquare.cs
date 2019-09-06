using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.UnityEventHelper;

public class EnableRuneSquare : MonoBehaviour
{
    public GameObject RuneSquare;
    public PatternRecognition patternRecognition;
    public GameObject runeSquareReference;

    private void Start()
    {
        runeSquareReference = RuneSquare;
        patternRecognition = FindObjectOfType<PatternRecognition>();
        DisableRuneSquare();
        
    }
    public void DisableRuneSquare()
    {
        
        patternRecognition.ResetBaseRuneSpawnerData();
        RuneSquare.SetActive(false);
        Debug.Log("The RuneSqaure is " + runeSquareReference.activeSelf);
    }
    public void ShowRuneSquare()
    {
        RuneSquare.SetActive(true);
        patternRecognition.ResetBaseRuneSpawnerData();
        Debug.Log("The RuneSqaure is " + runeSquareReference.activeSelf);

    }
    
    
}
