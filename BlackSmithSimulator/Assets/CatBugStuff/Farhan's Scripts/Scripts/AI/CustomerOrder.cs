using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrder : MonoBehaviour
{

    public int material;
    public int weapon_Type;
    public int enchantment;

    // Start is called before the first frame update
    void Start()
    {
        material = Random.Range(0, 3);
        weapon_Type = Random.Range(0, 2);
        enchantment = Random.Range(0, 2);
    }
}
