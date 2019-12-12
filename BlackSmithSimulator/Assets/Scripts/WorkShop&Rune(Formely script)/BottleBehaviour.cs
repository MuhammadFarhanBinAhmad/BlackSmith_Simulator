using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK.Controllables;

public class BottleBehaviour : MonoBehaviour
{
    Rigidbody rigidBody;
    bool isEnabled;
    public GameObject dropEffect;

    public GameobjectType objectType;
    public InteractableUIEffect UIEffect;

    public AudioSource glass_Braking;

    public enum GameobjectType
    {
        Prop,
        InteractableUI
    }

    public enum InteractableUIEffect
    {
        NoEffect,
        Teleport,
        MainMenu,
        QuitGame,
    }

    private void Start()
    {
        glass_Braking = GetComponent<AudioSource>();

        if (this.gameObject.activeInHierarchy == true)
        {
            isEnabled = true;
        }
        else
        {
            isEnabled = false;
        }
    }

    private void OnEnable()
    {
        if (rigidBody == null)
        {
            rigidBody = GetComponent<Rigidbody>();
        }
        isEnabled = true;
    }

    private void OnDisable()
    {
        isEnabled = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            print("Relative velocity is "+collision.relativeVelocity.magnitude);
        }

        if (Mathf.Round(collision.relativeVelocity.magnitude) >= 5  && collision.gameObject.layer == 9)
        {
            OnDrop();
        }
    }

    void OnDrop()
    {
        switch (objectType)
        {
            case GameobjectType.Prop:
                print("Velocity is " + Mathf.Round(rigidBody.velocity.magnitude * rigidBody.velocity.magnitude));
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                glass_Braking.Play();
                Destroy(this.gameObject);
                break;
            case GameobjectType.InteractableUI:
                print("Velocity is " + Mathf.Round(rigidBody.velocity.magnitude * rigidBody.velocity.magnitude));
                glass_Braking.Play();
                InteractableEffect();
                Destroy(this.gameObject);
                break;
        }
    }

    void InteractableEffect()
    {
        switch (UIEffect)
        {
            case InteractableUIEffect.NoEffect:
                break;
            case InteractableUIEffect.Teleport:
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                break;
            case InteractableUIEffect.MainMenu:
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                SceneManager.LoadScene("Pause_Main_Menu");
                break;
            case InteractableUIEffect.QuitGame:
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                Application.Quit();
                break;
        }
    }
}
