using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class newAIServant : MonoBehaviour
{
    public newAIMaster aIMasterRef;
    public newAIData aIData;
    public Character chara;


///Audio Data///
    public AudioSource audioSource;
    public AudioClip aiEntrance;
    public AudioClip[] aiIdle;
    public AudioClip aiWeapon1;
    public AudioClip aiWeapon2;
///Navigation///
    NavMeshAgent navMeshAgent;
    public bool walking;
///Animation///
    Animator aiAnimator;

    public enum Character
    {
        Philip,
        Solana   
    }

    void Start()
    {   
        aiAnimator = this.GetComponent<Animator>();
        navMeshAgent =this.GetComponent<NavMeshAgent>();
        audioSource = this.GetComponent<AudioSource>();
        audioSource.clip = null;
        assignAudio();
    }

    void assignAudio()
    {
        switch(chara)
        {
            case Character.Philip:
                aiEntrance = aIData.dialogueHumanEntrance1;
                aiIdle = aIData.dialogueHumanIdle;
                aiWeapon1 = aIData.dialogueHumanWeapon1;
                aiWeapon2 = aIData.dialogueHumanWeapon2;
                break;
            case Character.Solana:
                aiEntrance = aIData.dialogueDrowEntrance1;
                aiIdle = aIData.dialogueDrowIdle;
                aiWeapon1 = aIData.dialogueDrowWeapon1;
                aiWeapon2 = aIData.dialogueDrowWeapon2;
                break;
        }
    }

    public void WalkTo(Transform posToWalkTo)
    {
        walking = true;
        navMeshAgent.SetDestination(new Vector3(posToWalkTo.position.x,posToWalkTo.position.y,posToWalkTo.position.z));
        InvokeRepeating("Walking", 0.1f, 0.1f);
        InvokeRepeating("StopWalking", 0.1f, 0.1f);
    }
    private void Walking()
    {
        //Repeat animation for walking
    }

    private void StopWalking()
    {
        Debug.Log(navMeshAgent.remainingDistance +  " is distance to destination");
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            //any animation for stopping
            CancelInvoke("Walking");
            CancelInvoke("StopWalking");
            walking = false;
        }
    }

    public void Idle()
    {
        //animation for idle
    }

    public void PlayAudio(AudioClip ac)
    {
        audioSource.clip = ac;
        audioSource.Play();
    }
}
