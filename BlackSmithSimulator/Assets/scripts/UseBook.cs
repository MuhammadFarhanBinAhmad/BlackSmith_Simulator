using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;

public class UseBook : MonoBehaviour
{

        public VRTK_BaseControllable controllable;
        public BookBehaviour bookBehaviour;
        public bool isForward;

    public void Start()
    {
    }

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
            if (isForward == true)
            {
                bookBehaviour.NextPage();
            }
        else
            {
                bookBehaviour.PreviousPage();
            }
        }

        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {

        }
    
}
