using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInfo : MonoBehaviour
{
    public int weaponHiltValue;
    public int weaponMaterialValue;
    public int weaponTotalValue;
    public int weaponType;

    public MeshFilter thisMeshFilter;
    public MeshRenderer thisMeshRenderer;

    private void Start()
    {
        thisMeshFilter = this.GetComponent<MeshFilter>();
        thisMeshRenderer = this.GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        if (other.GetComponent<WeaponMaterial>() != null && other.GetComponent<WeaponMaterial>().materialState == 4)
        {
            other.gameObject.transform.position = this.gameObject.transform.position;
            other.transform.SetParent(this.gameObject.transform, false);
            other.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
    }

}
