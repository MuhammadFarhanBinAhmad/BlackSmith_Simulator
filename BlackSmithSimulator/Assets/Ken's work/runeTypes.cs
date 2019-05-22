using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTypes : MonoBehaviour
{
    public GameObject Rune;
    public Transform home;

    private void Awake()
    {
        //Instantiate(Rune, (home));
    }
    private void Start()
    {
        home = this.transform;
        CreatingNewRune();
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
        CreatingNewRune();
        print("New rune");
    }

    void CreatingNewRune()
    {
        Instantiate(Rune, home.transform.position, home.transform.rotation);
    }
}
