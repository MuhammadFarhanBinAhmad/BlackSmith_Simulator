using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using VRTK.UnityEventHelper;

public class EnableRuneSquare : MonoBehaviour
{
    public GameObject RuneSquare;

    public void EnableTheRuneSquare(object sender, ControllableEventArgs e)
    {
        RuneSquare.SetActive(true);
    }

    public void DisableTheRuneSquare(object sender, ControllableEventArgs e)
    {
        RuneSquare.SetActive(false);
    }
    
    
}
