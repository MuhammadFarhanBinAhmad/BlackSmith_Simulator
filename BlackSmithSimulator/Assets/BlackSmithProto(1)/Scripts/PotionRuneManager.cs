using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionRuneManager : MonoBehaviour
{
    public string catalyst, ingredient;
    public GameObject[] types = new GameObject[6];

    public int current_Type;

    public void EmptyPot()
    {
        catalyst = "";
        ingredient = "";
    }
    public void InstantiatePotion()
    {
        GameObject P = Instantiate(types[current_Type], transform.position, transform.rotation);
        EmptyPot();
    }
}
