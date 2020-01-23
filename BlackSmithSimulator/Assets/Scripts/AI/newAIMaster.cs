using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newAIMaster : MonoBehaviour
{

    /// <summary>
    /// This script controls most AI functions, except for navigation and animation
    /// </summary>

    public GameObject[] AIPrefabs; //Contains all AI Prefabs
    public newAIData[] AIData;
    public newAIData dataToRead;
    public GameObject currentControllingAI; //AI this script is controlling
    public newAIServant aiServantRef;

    private int[] currentOrderToSpawn;
    ///
    int customerServing; //current serving customer, is it the first or the second customer

    ///
    public Transform[] destPointsOfInterest;
    public Transform destCounter;
    public Transform destExit;

    void start()
    {
        InitialiseAIMaster();
    }

    void InitialiseAIMaster()
    {
        for (int i = 0; i < AIData.Length; i++)
        {
            if (AIData[i].day == GameManager.counterDay)
            {
                dataToRead = AIData[i];
            }
        }
        if (dataToRead != null)
        {
            ReadAndExecute();
        }
    }

    void ReadAndExecute()
    {   
        if(currentControllingAI != null)
        {
            Destroy(currentControllingAI);
        }
        currentControllingAI = Instantiate(AIPrefabs[customerServing], destExit.position,Quaternion.identity);
        aiServantRef = currentControllingAI.GetComponent<newAIServant>();
        aiServantRef.aIMasterRef = this;
        dataToRead = aiServantRef.aIData;
        WalkToCounter();
    }

    public void WalkToCounter()
    {
        aiServantRef.WalkTo(destCounter);
        while(aiServantRef.walking == true)
        {

        }
        aiServantRef.Idle();
        aiServantRef.PlayAudio(aiServantRef.aiEntrance);
        while(aiServantRef.audioSource.isPlaying == true)
        {

        }
        Idling();
    }

    public void Idling()
    {
        InvokeRepeating("PickRandomSpot", 0.1f, 5f);
    }
    private void PickRandomSpot()
    {
        currentControllingAI.GetComponent<newAIServant>().WalkTo(destPointsOfInterest[Random.Range(0, destPointsOfInterest.Length+1)]);
    }

    public void CollectWeapon()
    {
        CancelInvoke("PickRandomSpot");
    }

    public void Leave()
    {

    }
}
