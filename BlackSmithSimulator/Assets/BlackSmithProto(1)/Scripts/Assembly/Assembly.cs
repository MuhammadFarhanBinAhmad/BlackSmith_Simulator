using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembly : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ore")
        {
            if (other.GetComponent<Ore>().current_Stage == 5)
            {
                other.transform.SetParent(this.gameObject.transform);
            }
        }
    }
}
