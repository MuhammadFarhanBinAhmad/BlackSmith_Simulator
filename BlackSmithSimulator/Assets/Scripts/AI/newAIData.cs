using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AIData", menuName = "Data/AIData", order = 9)]
public class newAIData : ScriptableObject
{
    public int day;
    public AudioClip dialogueHumanEntrance1;
    public AudioClip dialogueHumanEntrance2;
    public AudioClip dialogueHumanEntrance3;
    public AudioClip[] dialogueHumanIdle;
    public AudioClip dialogueHumanWeapon1;
    public AudioClip dialogueHumanWeapon2;

    public AudioClip dialogueDrowEntrance1;
    public AudioClip dialogueDrowEntrance2;
    public AudioClip dialogueDrowEntrance3;
    public AudioClip[] dialogueDrowIdle;
    public AudioClip dialogueDrowWeapon1;
    public AudioClip dialogueDrowWeapon2;
}
