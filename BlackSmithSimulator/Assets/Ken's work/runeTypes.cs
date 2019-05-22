using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runeTypes : MonoBehaviour
{
    public GameObject Rune;
    public Transform home;

    private void Awake()
    {
        Instantiate(Rune, (home));
    }
    // Start timer when rune oj exit hitbox
    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(Runetimer(home));
    }
    // delay for new rune
    IEnumerator Runetimer (Transform home)
    {
        print("making new Rune");
        yield return new WaitForSeconds(10f);
        Instantiate(Rune, (home));
        print("New rune");
    }
}
