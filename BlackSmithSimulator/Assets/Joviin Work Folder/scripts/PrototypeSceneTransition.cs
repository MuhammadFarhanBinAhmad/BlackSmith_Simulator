using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK.Controllables;
using UnityEngine.SceneManagement;

public class PrototypeSceneTransition : MonoBehaviour
{
    public VRTK_BaseControllable controllable;


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
        if(FindObjectOfType<CustomerAI>() != null)
        {
            FindObjectOfType<CustomerAI>().CollectingWeapon();
        }
    }

    protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
    {
    }
}
