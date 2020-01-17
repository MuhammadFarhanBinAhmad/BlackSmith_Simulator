using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class BookBehaviour : MonoBehaviour
{
    public Material[] Pages;
    public int CurrentPage = 0;
    public MeshRenderer thisMeshRenderer;

    //public VRTK_InteractableObject bookZone;

    private void Start()
    {
        //bookZone = GetComponentInParent<VRTK_InteractableObject>();
        //bookZone.InteractableObjectUsed += OnPageFlip;

        thisMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        thisMeshRenderer.material = Pages[CurrentPage];
    }

    protected virtual void OnPageFlip(object sender, InteractableObjectEventArgs e)
    {
    }

    public void NextPage()
    {
        if (CurrentPage < Pages.Length)
        {
            CurrentPage++;
            thisMeshRenderer.material = Pages[CurrentPage];
            print("Turning to page "+CurrentPage);
        }
    }

    public void PreviousPage()
    {
        if (CurrentPage > 0)
        {
            CurrentPage--;
            thisMeshRenderer.material = Pages[CurrentPage];
            print("Turning to page "+CurrentPage);
        }
    }

}
