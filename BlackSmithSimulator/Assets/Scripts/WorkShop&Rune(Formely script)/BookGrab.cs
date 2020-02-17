using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookGrab : MonoBehaviour
{
    Rigidbody rbRef;

    private void Start()
    {
        rbRef = this.GetComponent<Rigidbody>();
    }

    public void GrabBook()
    {
        rbRef.constraints = RigidbodyConstraints.None;
    }

    public void UnGrabBook()
    {
        rbRef.constraints = RigidbodyConstraints.FreezeAll;
    }
}
