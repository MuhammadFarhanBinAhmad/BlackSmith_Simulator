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

    GameObject weapon_Drop_Point;

    CustomerPointOfInterest customer_Point_Of_Interest;

    public GameObject hand;

    //check weapon given to customer
    public bool correct_Weapon_Receive;
    bool given_Order;
    bool weapon_Recived;
    bool correct_Material;
    bool correct_Weapon_Type;
    bool correct_Enchantment;
    bool correct_Weapon;

    //bool turning;
    //float t = 0;

    int current_Animation_Element;
    int current_DestinationNumber;
    /// <summary>
    /// 0 = customer order
    /// </summary>
    public AudioSource customer_Dialouge;
    int current_Voiceline = 0;
    Animator customer_Anim;

    private void Awake()
    {
        customer_Dialouge = GetComponent<AudioSource>();
        the_Customer_Spawner = FindObjectOfType<CustomerSpawner>();
        customer_Point_Of_Interest = FindObjectOfType<CustomerPointOfInterest>();
        customer_Anim = GetComponent<Animator>();
        weapon_Drop_Point = GameObject.Find("BrokenWeaponSpawnPoint");
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //StartCoroutine(AIEntrance());
        agent.destination = the_Customer_Spawner.destPointsOfInterest[0].position;
        StartCoroutine("MovingToCounter");
    }

    IEnumerator MovingToCounter()
    {
        yield return new WaitForSeconds(1);
        agent.destination = the_Customer_Spawner.destCounter.position;
        InvokeRepeating("GoingToCounter", 0.1f, 0.1f);
    }

    public void CollectingWeapon()
    {
        if (given_Order && !weapon_Recived)//check if customer have given order and has his weapon receive
        {
            current_DestinationNumber = 0;
            agent.destination = the_Customer_Spawner.destCounter.position;//go to counter
            customer_Dialouge.Stop();
            customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element], false);//Stop idle animation
            CancelInvoke("StartWindowShopping");
            InvokeRepeating("GoingToCounter", 0.1f, 0.1f);
        }
    }
    void GoingToCounter()
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            {
            agent.updateRotation = true;

            if (current_DestinationNumber == 0)
                {
                //if order have been given...
                if (given_Order)
                {
                    //and weapon is present
                    if (FindObjectOfType<WeaponCollectionPoint>().ready_For_Collection)
                    {
                        print(FindObjectOfType<WeaponCollectionPoint>().ready_For_Collection);
                        //Exit Store
                        weapon_Recived = true;
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

                    if (customer_Order[GameManager.counterDay].customer_Dialouge_Speech[current_Voiceline] != null)
                    {
                        customer_Dialouge.clip = customer_Order[GameManager.counterDay].customer_Dialouge_Speech[current_Voiceline];
                        customer_Dialouge.Play();
                        current_Voiceline++;
                    }
                    if (customer_Order[GameManager.counterDay].broken_Weapon != null)
                    {
                        customer_Anim.SetBool("Giving", true);
                        StartCoroutine("GivingNote");
                        if (FindObjectOfType<VRTK.VRTK_SDKManager>() != null)
                        {
                            transform.LookAt(FindObjectOfType<VRTK.VRTK_SDKManager>().transform);
                        }
                        if (GameObject.Find("Test") != null)
                        {
                            transform.LookAt(GameObject.Find("Test").transform);
                        }
                    }
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
        new_Point_Of_Interest = Random.Range(1, customer_Point_Of_Interest.point_Of_Interest.Count-1);
        if (new_Point_Of_Interest == current_DestinationNumber)
        {
            MoveToNextPoint();
        }

        //transform.LookAt(the_Customer_Spawner.destPointsOfInterest[current_DestinationNumber]);

        if (new_Point_Of_Interest != current_DestinationNumber)
        {
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                    {
                        current_DestinationNumber = new_Point_Of_Interest;//give random point of interest for customer to move
                        agent.destination = the_Customer_Spawner.destPointsOfInterest[current_DestinationNumber].position;
                    }
                }
            }
        }
    }
    void CheckWeapon()
    {
        WeaponCollectionPoint the_Weapon_Collection_Point = FindObjectOfType<WeaponCollectionPoint>();
        StopCoroutine("CustomerIdling");
        //check all types if correct
        if (customer_Order[GameManager.counterDay].weapon_Material == the_Weapon_Collection_Point.material_Type)
        {
            correct_Material = true;
        }
        if (customer_Order[GameManager.counterDay].weapon_Type == the_Weapon_Collection_Point.weapon_Type)
        {
            correct_Weapon_Type = true;
        }
        if (customer_Order[GameManager.counterDay].weapon_Enchantment == the_Weapon_Collection_Point.enchantment_Type)
        {
            correct_Enchantment = true;
        }
        if (correct_Enchantment && correct_Weapon_Type && correct_Material)
        {
            correct_Weapon = true;
        }
        if (GameManager.counterDay == 1)
        {
            if (correct_Material && correct_Weapon_Type )
            {
                if (this.name == "Antoine(Clone)")
                {
                    AddKnightScore();
                }
                if (this.name == "Solana(Clone)")
                {
                    AddRougeScore();
                }
                current_Voiceline = 4;
            }
        }
        else if (correct_Weapon)
        {
            if (this.name == "Antoine(Clone)")
            {
                AddKnightScore();
            }
            if (this.name == "Solana(Clone)")
            {
                AddRougeScore();
            }
            current_Voiceline = 5;
        }
        StartCoroutine("ExitingStore");
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
                    print(CustomerSpawner.Customer_Already_Serve);
                    Destroy(gameObject);
                }
            }
        }
    }
    void AddKnightScore()
    {
        GameManager.scoreKnight++;
    }
    void AddRougeScore()
    {
        GameManager.scoreDrow++;
    }
    IEnumerator GivingNote()
    {
        yield return new WaitForSeconds(customer_Anim.GetCurrentAnimatorClipInfo(0).Length);
        Instantiate(customer_Order[GameManager.counterDay].broken_Weapon, weapon_Drop_Point.transform.position, Quaternion.Euler(90,0,0));//spawn ustomer broken weapon
        customer_Anim.SetBool("Giving", false);
        customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[0], true);//play customer order animation

    }
    IEnumerator RandomChatteringFromAI() //Animation, Navagent and Audio
    {
        yield return new WaitForSeconds(7);
        {
            if (customer_Order[CustomerSpawner.Customer_Already_Serve].customer_Dialouge_Speech[current_Voiceline] != null)
            {
                if (current_Voiceline != customer_Order[GameManager.counterDay].customer_Dialouge_Speech.Count)
                {
                    if (!customer_Dialouge.isPlaying)
                    {
                        if (current_Voiceline < 5)
                        {
                            customer_Dialouge.clip = customer_Order[GameManager.counterDay].customer_Dialouge_Speech[current_Voiceline];
                            customer_Dialouge.Play();
                            yield return new WaitForSeconds(customer_Order[GameManager.counterDay].customer_Dialouge_Speech[current_Voiceline].length);
                            current_Voiceline++;
                            StartCoroutine("RandomChatteringFromAI");
                        }
                    }
                }
            }
        }
    }
    //place animation here
    IEnumerator CustomerIdling() //Animation and Navagent only
    {
        //customer will idle for a period of time before moving to next location
        int times_Animation_Loops = Random.Range(0, 2);

        current_Animation_Element = Random.Range(1, the_Customer_Spawner.general_Customer_Anim.Count-1);
        customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element], true);//Start idle animation
        yield return new WaitForSeconds(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element].Length/2);
        customer_Anim.SetBool(the_Customer_Spawner.general_Customer_Anim[current_Animation_Element], false);//Stop idle animation
        MoveToNextPoint();
        InvokeRepeating("GoingToCounter", 0.1f, 0.1f);//Constantly checking Customer Location
    }
    //customer have receive waepon and leaving store
    IEnumerator ExitingStore() //Animation and Navagent only
    {
        CancelInvoke("StartWindowShopping");
        if (!correct_Weapon)
        {
            current_Voiceline = 6;
        }
        customer_Anim.SetBool("PickingUp", true);
        transform.LookAt(FindObjectOfType<VRTK.VRTK_SDKManager>().transform);
        //transform.LookAt(GameObject.Find("Test").transform);
        yield return new WaitForSeconds(0.18f);
        WeaponPosition();
        customer_Dialouge.clip = customer_Order[GameManager.counterDay].customer_Dialouge_Speech[current_Voiceline];
        customer_Dialouge.Play();
        yield return new WaitForSeconds(customer_Order[GameManager.counterDay].customer_Dialouge_Speech[current_Voiceline].length);//place grabing animation time here
        customer_Anim.SetBool("PickingUp", false);
        //current_DestinationNumber = the_Customer_Spawner.point_Of_Interest.Count - 1;
        agent.destination = the_Customer_Spawner.destExit.position;
        InvokeRepeating("ExitStore", 0, 0.1f);
    }
    void WeaponPosition()
    {
        FindObjectOfType<WeaponCollectionPoint>().created_Weapon.GetComponent<Rigidbody>().useGravity = false;
        FindObjectOfType<WeaponCollectionPoint>().created_Weapon.transform.SetParent(hand.transform);
        FindObjectOfType<WeaponCollectionPoint>().created_Weapon.transform.localPosition = new Vector3(0,0,0);
        FindObjectOfType<WeaponCollectionPoint>().created_Weapon.transform.localEulerAngles = new Vector3(-172,0,0);

    }
}
