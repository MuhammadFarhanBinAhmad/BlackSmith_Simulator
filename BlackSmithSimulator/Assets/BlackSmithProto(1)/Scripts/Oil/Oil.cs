using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oil : MonoBehaviour
{

    public int oil_Type;

    // Start is called before the first frame update
    void Start()
    {
        oil_Type = 1;
    }
    public void ChangeOil()
    {
        if (oil_Type >=0)
        {
            oil_Type++;
        }
        if (oil_Type ==3)
        {
            oil_Type = 1;
        }
    }
}
