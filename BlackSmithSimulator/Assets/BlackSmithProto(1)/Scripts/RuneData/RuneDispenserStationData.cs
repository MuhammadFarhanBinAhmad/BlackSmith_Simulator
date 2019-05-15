using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/RuneDispenserData")]
public class RuneDispenserStationData : ScriptableObject
{
    public RuneDispenserData the_Data_Of_Runes;
}
[System.Serializable]
public class RuneDispenserData
{
    public int FirstRuneData;
    public int SecondRuneData;
}
