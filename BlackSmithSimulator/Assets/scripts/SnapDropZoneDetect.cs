using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class SnapDropZoneDetect : MonoBehaviour
{
    public Fanvil fanvilRef;
    public VRTK_SnapDropZone toggleZoneA;

    protected virtual void OnEnable()
    {
        fanvilRef = FindObjectOfType<Fanvil>();
        toggleZoneA = GetComponent<VRTK_SnapDropZone>();
        toggleZoneA.ObjectSnappedToDropZone += OnSnap;
        toggleZoneA.ObjectUnsnappedFromDropZone += OnUnSnap;
    }

    protected virtual void OnSnap(object sender, SnapDropZoneEventArgs e)
    {
        //print(e.snappedObject.name + " Has been snapped");
        fanvilRef.AddRunes(e.snappedObject.gameObject);
    }

    protected virtual void OnUnSnap(object sender, SnapDropZoneEventArgs e)
    {
        //print(e.snappedObject.name + " Has been unsnapped");
        fanvilRef.RemoveRunes(e.snappedObject.gameObject);
    }
}
