using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeTypes : MonoBehaviour
{
    public GameObject Rune;
    public Transform home;
    // Start timer when rune oj exit hitbox
    private void OntriggerExit(Collider other)
    {
        StartCoroutine(Runetimer(home));
    }
    // delay for new rune
    IEnumerator Runetimer (Transform home)
    {
        yield return new WaitForSeconds(10f);
        Instantiate(Rune);
        print("New rune");
    }
}
