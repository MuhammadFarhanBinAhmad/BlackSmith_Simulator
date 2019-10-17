using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    NavMeshAgent agent;

    public WeaponData customer_Order;

    CustomerPointOfInterest the_Customer_Point_Of_Interest;

    public List<AudioSource> customer_Order_Speech = new List<AudioSource>();
    public List<AudioSource> customer_Idel_Chatting = new List<AudioSource>();

    CustomerSpawner the_Customer_Spawner;

    public bool correct_Weapon_Receive;
    bool given_Order;
    bool weapon_Recived;
    bool correct_Material;
    bool correct_Weapon_Type;
    bool correct_Enchantment;

    int current_DestinationNumber;

    private void Awake()
    {
        the_Customer_Point_Of_Interest = FindObjectOfType<CustomerPointOfInterest>();
    }
    void Start()
    {
        int moving_Speed = Random.Range(3,7);

        the_Customer_Spawner = FindObjectOfType<CustomerSpawner>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moving_Speed;
        agent.destination = the_Customer_Point_Of_Interest.point_Of_Interest[0].position;
        InvokeRepeating("GoingToCounter", 0.1f, 0.1f);
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Time.timeScale = 2;
        }
        if (Input.GetMouseButtonDown(0))//check if customer have given order and has his weapon receive
        {
            CollectingWeapon();
        }
    }

    public void CollectingWeapon()
    {
        if (given_Order && !weapon_Recived)//check if customer have given order and has his weapon receive
        {
            current_DestinationNumber = 0;
            agent.destination = the_Customer_Point_Of_Interest.point_Of_Interest[current_DestinationNumber].position;//go to counter
            customer_Idel_Chatting[0].Stop();//stop talking
            InvokeRepeating("GoingToCounter", 0.1f, 0.1f);
            print("CollectWeapon");
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
                            customer_Order_Speech[0].Play();//give order voice line
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
        if (!customer_Order_Speech[0].isPlaying)
        {
            MoveToNextPoint();
            given_Order = true;
            RandomChatteringFromAI();
            InvokeRepeating("GoingToCounter", 0.1f, 0.1f);//Constantly checking Customer Location
            CancelInvoke("StartWindowShopping");
        }
    }
    void RandomChatteringFromAI()//Customer start talking
    {
        customer_Idel_Chatting[0].Play();
    }
    //Customer exploring store
    void MoveToNextPoint()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                {
                    current_DestinationNumber = Random.Range(1, the_Customer_Point_Of_Interest.point_Of_Interest.Count - 2);//give random point of interest for customer to move
                    agent.destination = the_Customer_Point_Of_Interest.point_Of_Interest[current_DestinationNumber].position;
                }
            }
        }
    }
    void CheckWeapon()
    {

        WeaponCollectionPoint the_Weapon_Collection_Point = FindObjectOfType<WeaponCollectionPoint>();
        //check all types if correct
        if (customer_Order.weapon_Material == the_Weapon_Collection_Point.material_Type)
        {
            correct_Material = true;
        }
        if (customer_Order.weapon_Type == the_Weapon_Collection_Point.weapon_Type)
        {
            correct_Weapon_Type = true;
        }
        if (customer_Order.weapon_Enchantment == the_Weapon_Collection_Point.enchantment_Type)
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
                    the_Customer_Spawner.StartCoroutine("SpawnNextCustomer");//start timer to spawn next customer
                    the_Customer_Spawner.Customer_Already_Serve++;
                    print("customer server" + the_Customer_Spawner.Customer_Already_Serve);
                    Destroy(gameObject);
                }
            }
        }
    }
    //place animation here
    IEnumerator CustomerIdling()
    {
        //customer will idle for a period of time before moving to next location
        int wait_Time = Random.Range(8, 15);
        yield return new WaitForSeconds(wait_Time);
        MoveToNextPoint();
        InvokeRepeating("GoingToCounter", 0.1f, 0.1f);//Constantly checking Customer Location
    }
    //customer have receive waepon and leaving store
    IEnumerator ExitingStore()
    {
        yield return new WaitForSeconds(1.5f);//place grabing animation time here
        current_DestinationNumber = the_Customer_Point_Of_Interest.point_Of_Interest.Count - 1;
        agent.destination = the_Customer_Point_Of_Interest.point_Of_Interest[the_Customer_Point_Of_Interest.point_Of_Interest.Count - 1].position;
        InvokeRepeating("ExitStore", 0, 0.1f);
    }
}
