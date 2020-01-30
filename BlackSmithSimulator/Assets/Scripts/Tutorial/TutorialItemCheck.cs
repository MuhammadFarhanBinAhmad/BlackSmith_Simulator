using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemCheck : MonoBehaviour
{
    public bool runeItemCheck;
    public bool weaponItemCheck;
    public bool weaponenchantedItemCheck;

    void Start()
    {
        runeItemCheck = false;
        weaponItemCheck = false;
        weaponenchantedItemCheck = false;   
    }
}
