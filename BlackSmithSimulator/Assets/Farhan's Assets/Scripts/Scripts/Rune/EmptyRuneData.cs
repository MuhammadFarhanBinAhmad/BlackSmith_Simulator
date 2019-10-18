using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyRuneData : MonoBehaviour
{
    public RuneCreationData the_Rune_Creation_Data;
    public int this_Object_Catalyst;
    public int this_Object_Reactant;

    private void Start()
    {
        this_Object_Catalyst = the_Rune_Creation_Data.type_Catalyst_Data;
        this_Object_Reactant = the_Rune_Creation_Data.type_Reactant_Data;
    }
}
