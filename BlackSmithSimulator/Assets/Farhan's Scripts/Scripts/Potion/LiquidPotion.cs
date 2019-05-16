using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidPotion : MonoBehaviour
{
    public GameObject liquid_Box_Collider;

    // Update is called once per frame
    void FixedUpdate()
    {
        //input control here
        if (Input.GetMouseButton(0))
        {
            GameObject liquid_Content = Instantiate(liquid_Box_Collider, transform.position, transform.rotation);
        }
    }
}
