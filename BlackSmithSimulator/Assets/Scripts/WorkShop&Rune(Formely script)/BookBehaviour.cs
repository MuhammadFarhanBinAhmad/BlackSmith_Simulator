using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookBehaviour : MonoBehaviour
{
    public Material[] Pages;  
    public static int CurrentPage = 0;
    MeshRenderer thisMeshRenderer;

    private void Start()
    {
        thisMeshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        thisMeshRenderer.material = Pages[CurrentPage];
    }

    public void NextPage()
    {
        if (CurrentPage < Pages.Length)
        {
            CurrentPage++;
            thisMeshRenderer.material = Pages[CurrentPage];
        }
    }

    public void PreviousPage()
    {
        if (CurrentPage > 0)
        {
            CurrentPage--;
            thisMeshRenderer.material = Pages[CurrentPage];
        }
    }

}
