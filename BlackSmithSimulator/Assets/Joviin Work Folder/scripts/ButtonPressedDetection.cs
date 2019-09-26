using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class ButtonPressedDetection : MonoBehaviour
{
    public VRTK_BaseControllable controllable;
    public int thisObjectNumber;
    public bool isPushed;
    
    protected virtual void OnEnable()
    {
        controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);
        controllable.ValueChanged += ValueChanged;
        controllable.MaxLimitReached += MaxLimitReached;
        controllable.MinLimitReached += MinLimitReached;
    }

    protected virtual void ValueChanged(object sender, ControllableEventArgs e)
    {

    }

    protected virtual void MaxLimitReached(object sender, ControllableEventArgs e)
    {
        //print(e.interactingCollider.name);

            //when pressed
            //print("Button " + thisObjectNumber + " has been pressed"); 

            if(FindObjectOfType<PatternRecognition>().numbers_In_Code < 4)
            {
                FindObjectOfType<PatternRecognition>().buttonPressedNumber = thisObjectNumber;
                FindObjectOfType<PatternRecognition>().NumberHolder();
            GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialPusher>().SetStayPressed(true);
            }
                //send number to PatternRecognition

    }


    public IEnumerator BaseRuneCheckDelay(float waitTime)
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<VRTK.Controllables.ArtificialBased.VRTK_ArtificialPusher>().SetStayPressed(false);

    }



    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
    }
}
