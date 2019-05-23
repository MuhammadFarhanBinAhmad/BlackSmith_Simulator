using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTypes : MonoBehaviour
{
    public GameObject Rune;
    Transform home;
    public GameObject localRune;

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
        if (other.gameObject == localRune)
        {
            localRune = null;
            StartCoroutine(Runetimer(home));
        }

    }
    // delay for new rune
    IEnumerator Runetimer (Transform home)
    {
        print("Creating rune" + Rune.name);
        yield return new WaitForSeconds(10f);
        CreatingNewRune();
        print("Created new reun" + Rune.name);
    }

    void CreatingNewRune()
    {
       GameObject newLocalRune = Instantiate(Rune, home.transform.position, home.transform.rotation);
        localRune = newLocalRune;
    }
}
