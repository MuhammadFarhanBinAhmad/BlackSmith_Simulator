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
        bottleBreakSFX = GetComponent<AudioSource>();

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
        bottleBreakSFX.Play();
        print("Velocity is " + Mathf.Round(rigidBody.velocity.magnitude * rigidBody.velocity.magnitude));
        switch (objectType)
        {
            case GameobjectType.Prop:
                Instantiate(dropEffect, this.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(this.gameObject);
                break;
            case GameobjectType.InteractableUI:
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
