using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.UnityEventHelper;

public class EnableRuneSquare : MonoBehaviour
{
    public GameObject RuneSquare;

    private void Start()
    {
        DisableRuneSquare();
    }
    public void DisableRuneSquare()
    {
        RuneSquare.SetActive(false);
    }
    public void ShowRuneSquare()
    {
        RuneSquare.SetActive(true);
    }
    
    
}
