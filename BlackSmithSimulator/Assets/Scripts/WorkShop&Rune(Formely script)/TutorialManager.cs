using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TutorialManager : MonoBehaviour
{
    DarkSceneModeManager dsManager;

    //Tutorial mode
    public GameObject tutorialBoard;
    public Text tutorialText;
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
        tutorialText.text = "Grab object with x button";

        grabBottle = Instantiate(bottleToGrab, posToSpawn.position, Quaternion.Euler(0, 0, 0));
    }

    public void Tutorial2()
    {
        //throwing objects
        tutorialText.text = "Throw object with x button";
    }

    public void Tutorial3()
    {
        //teleporting
        tutorialText.text = "teleport with X button";

    }
    public void Tutorial4()
    {
        tutorialText.text = "Well done! you can teleport before and after serivce periods";
        StartCoroutine(TutorialEnd());
    }
    public IEnumerator TutorialEnd()
    {
        yield return new WaitForSeconds(7);
        dsManager.LevelModeSwitch("Pause_Main_Menu");
    }
}
