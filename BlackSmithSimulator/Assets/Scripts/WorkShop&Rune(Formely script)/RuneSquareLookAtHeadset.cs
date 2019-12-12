using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneSquareLookAtHeadset : MonoBehaviour
{
    public GameObject Headset;    
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.LookAt(Headset.transform);
    }
}
