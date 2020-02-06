using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneMaker : MonoBehaviour
{
    public GameObject runeSpawnLocation;
    public GameObject rune_Spawning_Effect;

    //ingredient currently in Dispenser
    public int catalyst_In_Dispenser, reactant_In_Dispenser;
    //current Rune type
    public int current_Type;

    public GameObject[] Rune_Types;
    GameObject catalystReference = null;
    GameObject reactantReference = null;


    public AudioSource rune_Maker_SFX;

    Animator animatorReference;

    private void Start()
    {
        rune_Maker_SFX = GetComponent<AudioSource>();
        animatorReference = GetComponent<Animator>();
    }

    public void AddRunes(GameObject RuneSelected)
    {
        if (RuneSelected.GetComponent<EmptyRuneData>() != null)
        {
            if (RuneSelected.GetComponent<EmptyRuneData>().this_Object_Catalyst != 0)
            {
                catalystReference = RuneSelected.gameObject;
                catalyst_In_Dispenser = RuneSelected.GetComponent<EmptyRuneData>().this_Object_Catalyst;
                CheckRune();
            }

            if (RuneSelected.GetComponent<EmptyRuneData>().this_Object_Reactant != 0)
            {
                reactantReference = RuneSelected.gameObject;
                reactant_In_Dispenser = RuneSelected.GetComponent<EmptyRuneData>().this_Object_Reactant;
                CheckRune();
            }
        }
    }

    public void RemoveRunes(GameObject RuneSelected)
    {
        //Remove Base Rune if left RuneMaker
        if (RuneSelected.GetComponent<EmptyRuneData>() != null)
        {
            if (RuneSelected.GetComponent<EmptyRuneData>().this_Object_Catalyst != 0 || RuneSelected.gameObject == catalystReference)
            {
                catalystReference = null;
                catalyst_In_Dispenser = 0;
            }

            if (RuneSelected.GetComponent<EmptyRuneData>().this_Object_Reactant != 0 || RuneSelected.gameObject == reactantReference)
            {
                reactantReference = null;
                reactant_In_Dispenser = 0;
            }
        }
    }

    void CheckRune()
    {
        GameObject runeRef;
        if (catalyst_In_Dispenser != 0 && reactant_In_Dispenser != 0)
        {
            //All Combination for runes
            if (catalyst_In_Dispenser == 1)
            {
                if (reactant_In_Dispenser == 1)
                {
                    current_Type = 1;
                }
                if (reactant_In_Dispenser == 2)
                {
                    current_Type = 2;
                }
                // Old Axe Rune
                if (reactant_In_Dispenser == 3)
                {
                    current_Type = 3;
                }
                if (reactant_In_Dispenser == 4)
                {
                    current_Type = 4;
                }
            }
            if (catalyst_In_Dispenser == 2)
            {
                if (reactant_In_Dispenser == 1)
                {
                    current_Type = 5;
                }
                if (reactant_In_Dispenser == 2)
                {
                    current_Type = 6;
                }
                if (reactant_In_Dispenser == 3)
                {
                    current_Type = 7;
                }
                if (reactant_In_Dispenser == 4)
                {
                    current_Type = 8;
                }
            }
            if (catalyst_In_Dispenser == 3)
            {
                if (reactant_In_Dispenser == 1)
                {
                    current_Type = 9;
                }
                if (reactant_In_Dispenser == 2)
                {
                    current_Type = 10;
                }
                if (reactant_In_Dispenser == 3)
                {
                    current_Type = 11;
                }
                if (reactant_In_Dispenser == 4)
                {
                    current_Type = 12;
                }
            }
            if (current_Type != 0)
            {
                animatorReference.SetBool("CreatingRune",true);
                Instantiate(rune_Spawning_Effect, runeSpawnLocation.transform.position, Quaternion.Euler(0, 0, -110));
                runeRef = Instantiate(Rune_Types[current_Type], runeSpawnLocation.transform.position, Quaternion.Euler(0, 0, -110));
                if (rune_Maker_SFX != null)
                {
                    rune_Maker_SFX.Play();
                }
                runeRef.GetComponent<RuneData>().runeMakerRef = this.GetComponent<RuneMaker>();
                EmptyPot();
            }
        }
    }

    public void EmptyPot()
    {
        Destroy(catalystReference.gameObject);
        Destroy(reactantReference.gameObject);
        catalystReference = null;
        reactantReference = null;
        catalyst_In_Dispenser = 0;
        reactant_In_Dispenser = 0;
        current_Type = 0;
    }

    public void OnPickUpRuneMixer()
    {
        //rune has been picked up
        animatorReference.SetBool("CreatingRune", false);
        print("Rune has been picked up from maker");
    }
}
