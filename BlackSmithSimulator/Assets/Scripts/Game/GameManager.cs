using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform startingPos;
    GameObject CameraRig;

    private void Start()
    {
        StartCoroutine(CentrePlayer());
    }

    IEnumerator CentrePlayer()
    {
        yield return new WaitForSeconds(1);
        CameraRig = FindObjectOfType<SteamVR_ControllerManager>().gameObject;
        Debug.Log(CameraRig.name);
    }
}
