using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;

public class FloatingObjectGrab : MonoBehaviour
{
    public void UnfreezeObject()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    public void UnfreezeObjectTutorial()
    {
        this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        FindObjectOfType<TutorialManager>().Tutorial3();
    }
    public void TutorialDrop()
    {
        FindObjectOfType<TutorialManager>().Tutorial4();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (Mathf.Round(collision.relativeVelocity.magnitude) >= 5 && collision.gameObject.layer == 9)
        {
            TutorialDrop();
        }
    }
}