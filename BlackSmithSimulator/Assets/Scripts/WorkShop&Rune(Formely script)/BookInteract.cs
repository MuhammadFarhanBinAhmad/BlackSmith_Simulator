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
    
    public void TurnPage()
    {
        switch (pageflip)
        {
            case PageFlipDirection.PreviousPage:
                bookBehaviour.PreviousPage();
                break;
            case PageFlipDirection.NextPage:
                bookBehaviour.NextPage();
                break;
        }
    }

}
