using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class RuneMixerSnapDropZone : MonoBehaviour
{
    public RuneMaker runeMixerRef;
    public VRTK_SnapDropZone toggleZoneA;

    protected virtual void OnEnable()
    {
        runeMixerRef = FindObjectOfType<RuneMaker>();
        toggleZoneA = GetComponent<VRTK_SnapDropZone>();
        toggleZoneA.ObjectSnappedToDropZone += OnSnap;
        toggleZoneA.ObjectUnsnappedFromDropZone += OnUnSnap;
    }

    protected virtual void OnSnap(object sender, SnapDropZoneEventArgs e)
    {
        //print(e.snappedObject.name + " Has been snapped");
        runeMixerRef.AddRunes(e.snappedObject.gameObject);
    }

    protected virtual void OnUnSnap(object sender, SnapDropZoneEventArgs e)
    {
        //print(e.snappedObject.name + " Has been unsnapped");
        runeMixerRef.RemoveRunes(e.snappedObject.gameObject);
    }
}
