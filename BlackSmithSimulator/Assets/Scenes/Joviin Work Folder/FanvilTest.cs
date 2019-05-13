using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanvilTest : MonoBehaviour
{
   public List<GameObject> MaterialsCollected = new List<GameObject>(9);


    private void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            MaterialsCollected.Add(null);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        print(other.transform.InverseTransformPoint(GameObject.Find("FanvilBase").transform.localPosition));
        if (other.name == "Ore(Copper)")
        {
            
            if (other.transform.localPosition.x < -0.2 && other.transform.localPosition.x >-0.5 && other.transform.localPosition.z < 0.5 && other.transform.localPosition.z > 0.2)
            {
                MaterialsCollected.Add(other.gameObject);
            }
        }
    }
}
