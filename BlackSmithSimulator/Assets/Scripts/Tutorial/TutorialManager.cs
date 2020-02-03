﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    DarkSceneModeManager dsManager;

    //Tutorial mode
    public GameObject tutorialBoard;
    public Image darkSceneTutorialImage;
    public Sprite[] darkSceneTutorialImages;
    public GameObject bottleToGrab;
    public Transform posToSpawn;
    public GameObject bottleSpotLight;

    public GameObject teleportSpotLight;
    public GameObject teleportPointer;

    GameObject grabBottle;

    private void Start()
    {
        dsManager = FindObjectOfType<DarkSceneModeManager>();
    }

    public void Tutorial1()
    {  
        tutorialBoard.SetActive(true);
        //tutorialText.text = "Grab object with x button";
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[0];
        teleportSpotLight.SetActive(true);
        teleportPointer.SetActive(true);
    }

    public void Tutorial2()
    {

        //new grabbing objects
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[1];
        grabBottle = Instantiate(bottleToGrab, posToSpawn.position, Quaternion.Euler(0, 0, 0));
        bottleSpotLight.SetActive(true);
    }

    public void Tutorial3()
    {
 
        //new throwing objects
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[2];
        bottleSpotLight.SetActive(false);

    }
    public void Tutorial4()
    {
        //tutorialText.text = "Well done! you can teleport before and after serivce periods";
        if (darkSceneTutorialImage.sprite == darkSceneTutorialImages[2])
        {
            teleportSpotLight.SetActive(false);
            darkSceneTutorialImage.sprite = darkSceneTutorialImages[3];
            StartCoroutine(TutorialEnd());
        }
    }
    public IEnumerator TutorialEnd()
    {
        yield return new WaitForSeconds(5);
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[4];
        StartCoroutine(dsManager.LevelToLoad("Pause_Main_Menu"));
        //dsManager.LevelModeSwitch("Pause_Main_Menu");
    }

    public void CheckTeleportDuringTutorial(){
        if (darkSceneTutorialImage.sprite == darkSceneTutorialImages[2]){
            Tutorial4();
        }

    }
}
