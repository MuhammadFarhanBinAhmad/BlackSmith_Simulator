using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class TutorialListner : MonoBehaviour
{
    public AudioClip[] audioClips;
    [SerializeField]
    bool[] step;
    public void FlipToNextPage()
    {
        //step 0
        if (step[0] != true)
        {
        print("check ok! proceeding with step 0");            
            //executecommand
            step[0] = true;
        }
    }

    public void OpenRuneSquare()
    {
        //step 1
        if (step[0] == true && step[1] != true)
        {
        print("check ok! proceeding with step 1");            
            //executecommand
            step[1] = true;
        }
    }

    public void CreateBaseRune1()
    {
        //step 2
        if (step[1] == true && step[2] != true)
        {
        print("check ok! proceeding with step 2");            
            //executecommand
            step[2] = true;
        }    
    }
    
    public void PickUpBaseRune1()
    {
        //step 3
        if (step[2] == true && step[3] != true)
        {
        print("check ok! proceeding with step 3");            
            //executecommand
            step[3] = true;
        }     
    }

    public void PlaceBaseRune1OnRuneCombiner()
    {
        //step 4
        if (step[3] == true && step[4] != true)
        {
        print("check ok! proceeding with step 4");            
            //executecommand
            step[4] = true;
        }      
    }

    public void PickUpBaseRune2()
    {
        //step 5
        if (step[4] == true && step[5] != true)
        {
        print("check ok! proceeding with step 5");            
            //executecommand
            step[5] = true;
        }   
    }

    public void PlaceBaseRune2OnRuneCombiner()
    {
        //step 6
        if (step[5] == true && step[6] != true)
        {
        print("check ok! proceeding with step 6");            
            //executecommand
            step[6] = true;
        }     
    }

    public void PlaceRune1InFanvil()
    {
        //step 7
        if (step[6] == true && step[7] != true)
        {
        print("check ok! proceeding with step 7");            
            //executecommand
            step[7] = true;
        }  
    }

    public void PickUpRune2()
    {
        //step 8
        if (step[7] == true && step[8] != true)
        {
        print("check ok! proceeding with step 8");            
            //executecommand
            step[8] = true;
        }      
    }

    public void PlaceRune2InFanvil()
    {
        //step 9
        if (step[8] == true && step[9] != true)
        {
        print("check ok! proceeding with step 9");            
            //executecommand
            step[9] = true;
        }    
    }

    public void PlaceOreInFanvil()
    {
        //step 10
        if (step[9] == true && step[10] != true)
        {
        print("check ok! proceeding with step 10");            
            //executecommand
            step[10] = true;
        }    
    }

    public void UseFanvil()
    {
        //step 11
        if (step[10] == true && step[11] != true)
        {
        print("check ok! proceeding with step 11");            
            //executecommand
            step[11] = true;
        }       
    }

    public void WeaponOnTable()
    {
        //step 12
        if (step[11] == true && step[12] != true)
        {
        print("check ok! proceeding with step 12");            
            //executecommand
            step[12] = true;
        }      
    }

    public void PickUpRune3()
    {
        //step 13
        if (step[12] == true && step[13] != true)
        {
        print("check ok! proceeding with step 13");            
            //executecommand
            step[13] = true;
        }       
    }
    public void PlaceRune3OnWeapon()
    {
        //step 14
        if (step[13] == true && step[14] != true)
        {
        print("check ok! proceeding with step 14");            
            //executecommand
            step[14] = true;
        }   
    }

    public void RingBell()
    {
        //step 15
        if (step[14] == true && step[15] != true)
        {
        print("check ok! proceeding with step 15");            
            //executecommand
            step[15] = true;
        }      
    }

    public void RingBell2()
    {
        //step 16
        if (step[15] == true && step[16] != true)
        {
        print("check ok! proceeding with step 16");            
            //executecommand
            step[16] = true;
        }  
    }
}
