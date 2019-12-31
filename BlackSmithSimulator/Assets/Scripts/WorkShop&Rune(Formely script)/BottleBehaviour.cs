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

    public AudioSource bottleBreakSFX;

    public enum GameobjectType
    {
        Prop,
        Interactable    
    }

    public enum InteractableUIEffect
    {
        NoEffect,
        Teleport,
        MainMenu,
        QuitGame,
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
        print("Velocity is " + Mathf.Round(rigidBody.velocity.magnitude * rigidBody.velocity.magnitude));
        switch (objectType)
        {
            case GameobjectType.Prop:
                break;
            case GameobjectType.Interactable:
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
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                this.GetComponent<AudioSource>().Play();
                break;
            case InteractableUIEffect.Teleport:
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                this.GetComponent<AudioSource>().Play();
                break;
            case InteractableUIEffect.MainMenu:
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                this.GetComponent<AudioSource>().Play();
                SceneManager.LoadScene("Pause_Main_Menu");
                break;
            case InteractableUIEffect.QuitGame:
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                this.GetComponent<AudioSource>().Play();
                Application.Quit();
                break;
        }
    }
}
