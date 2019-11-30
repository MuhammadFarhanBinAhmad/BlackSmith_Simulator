using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapDropZoneDetect : MonoBehaviour
{
    public GameObject snappedObject;
    public Fanvil fanvilRef;

    private void Start()
    {
        snappedObject = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RuneData>() != null)
        {
            snappedObject = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<RuneData>() != null)
        {
            snappedObject = null;
        }
    }

    public void AddRuneToFanvil()
    {
        fanvilRef.AddRunes(snappedObject);
    }

    public void RemoveRuneToFanvil()
    {
        fanvilRef.RemoveRunes(snappedObject);
    }
}
