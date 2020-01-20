using System.Collections;
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

    GameObject grabBottle;

    private void Start()
    {
        dsManager = FindObjectOfType<DarkSceneModeManager>();
    }

    public void Tutorial1()
    {
        //grabbing objects
        tutorialBoard.SetActive(true);
        //tutorialText.text = "Grab object with x button";
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[0];

        grabBottle = Instantiate(bottleToGrab, posToSpawn.position, Quaternion.Euler(0, 0, 0));
    }

    public void Tutorial2()
    {
        //throwing objects
        //tutorialText.text = "Throw object with x button";
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[1];
    }

    public void Tutorial3()
    {
        //teleporting
        //tutorialText.text = "teleport with X button";
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[2];

    }
    public void Tutorial4()
    {
        //tutorialText.text = "Well done! you can teleport before and after serivce periods";
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[3];
        StartCoroutine(TutorialEnd());
    }
    public IEnumerator TutorialEnd()
    {
        yield return new WaitForSeconds(5);
        StartCoroutine(dsManager.LevelToLoad("Pause_Main_Menu"));
        //dsManager.LevelModeSwitch("Pause_Main_Menu");
        darkSceneTutorialImage.sprite = darkSceneTutorialImages[4];
    }

    public void CheckTeleportDuringTutorial(){
        if (darkSceneTutorialImage.sprite == darkSceneTutorialImages[2]){
            Tutorial4();
        }

    }
}
