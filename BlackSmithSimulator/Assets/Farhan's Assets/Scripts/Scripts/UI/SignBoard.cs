using UnityEngine;

public class SignBoard : MonoBehaviour
{
    public bool store_Open;

    CustomerSpawner the_Customer_Spawn;

    private void Start()
    {
        the_Customer_Spawn = FindObjectOfType<CustomerSpawner>();
    }

    private void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        RaycastHit hit;
        //Check which side the board is facing
        if (Physics.Raycast(transform.position, fwd, out hit, 0.5f))
        {
            if (hit.collider.gameObject.name == "StoreOpenBoxCollider" && !store_Open)
            {
                store_Open = true;
                the_Customer_Spawn.StartCoroutine("SpawnNextCustomer");
            }
            if (hit.collider.gameObject.name == "StoreCloseBoxCollider" && store_Open && the_Customer_Spawn.Customer_Already_Serve == 3)
            {
                store_Open = false;
                the_Customer_Spawn.NextDay();
            }
            Debug.DrawRay(transform.position, fwd, Color.blue);
        }
    }
}
