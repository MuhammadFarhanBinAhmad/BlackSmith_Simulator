using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Prototype Only
using UnityEngine.UI;

public class ThisWeaponData : MonoBehaviour
{
    //this object data
    public int this_Weapon_Type;
    public int this_Material_Type;
    public int this_Enchantment_Type;

    //Prototype Only
    public GameObject[] ParticleEffects;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<RuneData>() != null)
        {
            if (other.GetComponent<RuneData>().enchantment_Type != 0)
            {
                this_Enchantment_Type = other.GetComponent<RuneData>().enchantment_Type;
                print("Enchanting with enchantment type" + this_Enchantment_Type);
                Destroy(other.gameObject);

                //Prototype Only
                GameObject LocalParticle;
                LocalParticle = Instantiate(ParticleEffects[this_Enchantment_Type], this.gameObject.transform);
                LocalParticle.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }


}
