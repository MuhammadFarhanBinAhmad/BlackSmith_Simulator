using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{

    /// <summary>
    /// For Weapon data and customer voice line, go to WeaponData Scripts
    /// for AI related and Day data, go to weapon CustomerSpawner scripts
    /// </summary>

    NavMeshAgent agent;

    public List<WeaponData> customer_Order = new List<WeaponData>();

    CustomerSpawner the_Customer_Spawner;

    //check weapon given to customer
    public bool correct_Weapon_Receive;
    bool given_Order;
    bool weapon_Recived;
    bool correct_Material;
    bool correct_Weapon_Type;
    bool correct_Enchantment;

    int current_Animation_Element;
    int current_DestinationNumber;
    /// <summary>
    /// 0 = customer order
    /// </summary>
    public AudioSource customer_Dialouge;
    int current_Anim_Element = 1;

    Animator customer_Anim;

    private void Awake()
    {
        customer_Dialouge = GetComponent<AudioSource>();
        the_Customer_Spawner = FindObjectOfType<CustomerSpawner>();
        customer_Anim = GetComponent<Animator>();
    }
    void Start()
    {

        agent = GetComponent<NavMeshAgent>();
        agent.speed = 5;
        agent.destination = the_Customer_Spawner.point_Of_Interest[1].position;
        StartCoroutine("MovingToCounter");
    }

    IEnumerator MovingToCounter()
    {
        yield return new WaitForSeconds(1);
        agent.destination = the_Customer_Spawner.point_Of_Interest[0].position;
        InvokeRepeating("GoingToCounter", 0.1f, 0.1f);
    }

    public void CollectingWeapon()
    {
        if (given_Order && !weapon_Recived)//check if customer have given order and has his weapon receive
        {
            current_DestinationNumber = 0;
            agent.destination = the_Customer_Spawner.point_Of_Interest[current_DestinationNumber].position;//go to counter
            customer_Dialouge.Stop();
            customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element], false);//Stop idle animation
            InvokeRepeating("GoingToCounter", 0.1f, 0.1f);
        }
    }
    void GoingToCounter()
    {
        //check if AI has reach his destination
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    if (current_DestinationNumber == 0)
                    {
                        //if order have been given...
                        if (given_Order)
                        {
                            //and weapon is present
                            if (FindObjectOfType<WeaponCollectionPoint>().ready_For_Collection)
                            {
                                //Exit Store
                                StartCoroutine("ExitingStore");
                                weapon_Recived = true;
                                Destroy(FindObjectOfType<ThisWeaponData>().gameObject);
                                CheckWeapon();
                                CancelInvoke("GoingToCounter");
                            }
                            //if no weapon is present
                            else
                            {
                                //Go back to Window Shopping
                                InvokeRepeating("StartWindowShopping", 0, 0.1f);
                            }
                        }
                        //customer giving order
                        else if (!given_Order)
                        {
                            customer_Dialouge.clip = customer_Order[CustomerSpawner.Customer_Already_Serve].customer_Dialouge_Speech[0];
                            customer_Dialouge.Play();
                            customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[0], true);//play customer order animation
                            InvokeRepeating("StartWindowShopping", 0, 0.1f);
                            CancelInvoke("GoingToCounter");
                        }
                    }
                    else
                    //customer moving and looking around store
                    {
                        StartCoroutine("CustomerIdling");
                        CancelInvoke("GoingToCounter");
                    }
                }
            }
        }
    }
    void StartWindowShopping()
    {
        //customer start exploring and moving aroud store
        if (!customer_Dialouge.isPlaying)
        {
            customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[0], false);//stop customer order animation
            MoveToNextPoint();
            given_Order = true;
            StartCoroutine("RandomChatteringFromAI");
            InvokeRepeating("GoingToCounter", 0.1f, 0.1f);//Constantly checking Customer Location
            CancelInvoke("StartWindowShopping");
        }
    }
    //Customer exploring store
    void MoveToNextPoint()
    {
        int new_Point_Of_Interest;

        //ensure that the same number dont appear twice
        new_Point_Of_Interest = Random.Range(2, the_Customer_Spawner.point_Of_Interest.Count - 2);
        if (new_Point_Of_Interest == current_DestinationNumber)
        {
            MoveToNextPoint();
        }
        if (new_Point_Of_Interest != current_DestinationNumber)
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                    {
                        current_DestinationNumber = new_Point_Of_Interest;//give random point of interest for customer to move
                        agent.destination = the_Customer_Spawner.point_Of_Interest[current_DestinationNumber].position;
                    }
                }
            }
        }
    }
    void CheckWeapon()
    {

        WeaponCollectionPoint the_Weapon_Collection_Point = FindObjectOfType<WeaponCollectionPoint>();
        //check all types if correct
        if (customer_Order[CustomerSpawner.current_day].weapon_Material == the_Weapon_Collection_Point.material_Type)
        {
            correct_Material = true;
        }
        if (customer_Order[CustomerSpawner.current_day].weapon_Type == the_Weapon_Collection_Point.weapon_Type)
        {
            correct_Weapon_Type = true;
        }
        if (customer_Order[CustomerSpawner.current_day].weapon_Enchantment == the_Weapon_Collection_Point.enchantment_Type)
        {
            correct_Enchantment = true;
        }
        if (correct_Material && correct_Weapon_Type && correct_Enchantment)
        {
            correct_Weapon_Receive = true;
        }
    }
    void ExitStore()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    FindObjectOfType<CustomerSpawner>().StartCoroutine("SpawnNextCustomer");//start timer to spawn next customer
                    CustomerSpawner.Customer_Already_Serve++;
                    Destroy(gameObject);
                }
            }
        }
    }
    IEnumerator RandomChatteringFromAI()
    {
        yield return new WaitForSeconds(7);
        {
            if (current_Anim_Element != customer_Order[CustomerSpawner.Customer_Already_Serve].customer_Dialouge_Speech.Count)
            {
                if (!customer_Dialouge.isPlaying)
                {
                    customer_Dialouge.clip = customer_Order[CustomerSpawner.Customer_Already_Serve].customer_Dialouge_Speech[current_Anim_Element];
                    customer_Dialouge.Play();
                    yield return new WaitForSeconds(customer_Order[CustomerSpawner.Customer_Already_Serve].customer_Dialouge_Speech[current_Anim_Element].length);
                    current_Anim_Element++;
                    StartCoroutine("RandomChatteringFromAI");
                }
            }
        }
    }
    //place animation here
    IEnumerator CustomerIdling()
    {
        //customer will idle for a period of time before moving to next location
        int times_Animation_Loops = Random.Range(0, 2);

        current_Animation_Element = Random.Range(0, the_Customer_Spawner.general_Customer_Anim.Count);
        customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element], true);//Start idle animation
        yield return new WaitForSeconds(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element].Length/2);
        customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element], false);//Stop idle animation
        MoveToNextPoint();
        InvokeRepeating("GoingToCounter", 0.1f, 0.1f);//Constantly checking Customer Location
    }
    //customer have receive waepon and leaving store
    IEnumerator ExitingStore()
    {
        customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[0], true);//stop customer order animation
        yield return new WaitForSeconds(1.5f);//place grabing animation time here
        customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[0], false);//stop customer order animation
        current_DestinationNumber = the_Customer_Spawner.point_Of_Interest.Count - 1;
        agent.destination = the_Customer_Spawner.point_Of_Interest[the_Customer_Spawner.point_Of_Interest.Count - 1].position;
        InvokeRepeating("ExitStore", 0, 0.1f);
    }
}
