using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2 : MonoBehaviour
{
    public TutorialEvent tEvents;
    TutorialListner tListner;

    public enum TutorialEvent
    {
        FlipToNextPage,
        OpenRuneSquare,
        CreateBaseRune1,
        PickUpBaseRune1,
        PlaceBaseRune1OnRuneCombiner,
        PickUpBaseRune2,
        PlaceBaseRune2OnRuneCombiner,
        PlaceRune1InFanvil,
        PickUpRune2,
        PlaceRune2InFanvil,
        PlaceOreInFanvil,
        UseFanvil,
        WeaponOnTable,
        PickUpRune3,
        PlaceRune3OnWeapon,
        RingBell,
        RingBell2
    }

    private void Start()
    {
       tListner = FindObjectOfType<TutorialListner>();
    }

    public void TutorialEventSend()
    {
        switch (tEvents)
        {
            case TutorialEvent.FlipToNextPage:
                tListner.FlipToNextPage();
                break;
            case TutorialEvent.OpenRuneSquare:
                tListner.OpenRuneSquare();
                break;
            case TutorialEvent.CreateBaseRune1:
                tListner.CreateBaseRune1();
                break;
            case TutorialEvent.PickUpBaseRune1:
                tListner.PickUpBaseRune1();
                break;
            case TutorialEvent.PlaceBaseRune1OnRuneCombiner:
                tListner.PlaceBaseRune1OnRuneCombiner();
                break;
            case TutorialEvent.PickUpBaseRune2:
                tListner.PickUpBaseRune2();
                break;
            case TutorialEvent.PlaceBaseRune2OnRuneCombiner:
                tListner.PlaceBaseRune2OnRuneCombiner();
                break;
            case TutorialEvent.PlaceRune1InFanvil:
                tListner.PlaceRune1InFanvil();
                break;
            case TutorialEvent.PickUpRune2:
                tListner.PickUpRune2();
                break;
            case TutorialEvent.PlaceRune2InFanvil:
                tListner.PlaceRune2InFanvil();
                break;
            case TutorialEvent.PlaceOreInFanvil:
                tListner.PlaceOreInFanvil();
                break;
            case TutorialEvent.UseFanvil:
                tListner.UseFanvil();
                break;
            case TutorialEvent.WeaponOnTable:
                tListner.WeaponOnTable();
                break;
            case TutorialEvent.PickUpRune3:
                tListner.PickUpRune3();
                break;
            case TutorialEvent.PlaceRune3OnWeapon:
                tListner.PlaceRune3OnWeapon();
                break;
            case TutorialEvent.RingBell:
                tListner.RingBell();
                break;
            case TutorialEvent.RingBell2:
                tListner.RingBell2();
                break;
        }
    }
}
