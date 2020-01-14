using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2Manager : MonoBehaviour
{
    public List<AudioClip> tVoicelines = new List<AudioClip>();
    public TutorialEvent tEvent;

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


    public void Tutorial(TutorialEvent tEvents)
    {
        
    }
}
