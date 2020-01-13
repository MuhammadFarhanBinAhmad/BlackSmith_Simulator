using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using VRTK.Controllables;

public class BookInteract : MonoBehaviour
{
    public VRTK_InteractableObject linkedObject;
    public BookBehaviour bookBehaviour;

    public PageFlipDirection pageflip;

    public enum PageFlipDirection
    {
        PreviousPage,
        NextPage
    }

    protected virtual void OnEnable()
    {
        linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);

        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed += InteractableObjectUsed;
            linkedObject.InteractableObjectUnused += InteractableObjectUnused;
        }
    }

    protected virtual void OnDisable()
    {

        if (linkedObject != null)
        {
            linkedObject.InteractableObjectUsed -= InteractableObjectUsed;
            linkedObject.InteractableObjectUnused -= InteractableObjectUnused;
        }
    }

    protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
    {
        //Object used = toggle on

        switch (pageflip)
        {
            case PageFlipDirection.PreviousPage:
                bookBehaviour.PreviousPage();
                break;
            case PageFlipDirection.NextPage:
                bookBehaviour.NextPage();
                break;
        }
        //bookBehaviour.NextPage();
    }

    protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
    {
        //Object unused = toggle off
        switch (pageflip)
        {
            case PageFlipDirection.PreviousPage:
                bookBehaviour.PreviousPage();
                break;
            case PageFlipDirection.NextPage:
                bookBehaviour.NextPage();
                break;
        }
        //bookBehaviour.NextPage();
    }


}
