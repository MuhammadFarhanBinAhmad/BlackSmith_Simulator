using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialUIHelp : MonoBehaviour
{
    public GameObject Uiholder;
    public TextMeshProUGUI tmProGUILeft;
    public TextMeshProUGUI tmProGUIRight;

    [TextArea]
    public string[] pageUIText;


    private void Start()
    {
        Uiholder.SetActive(false);
    }

    public void ShowHelpUI()
    {
        StartCoroutine(HelpUi((FindObjectOfType<BookBehaviour>().CurrentPage) * 2 + 1, (FindObjectOfType<BookBehaviour>().CurrentPage) * 2 + 1));
    }

    IEnumerator HelpUi(int pageNoLeft, int pageNoRight)
    {
        Uiholder.SetActive(true);
        tmProGUILeft.text = pageUIText[pageNoLeft];
        tmProGUIRight.text = pageUIText[pageNoRight];
        yield return new WaitForSecondsRealtime(10f);
        Uiholder.SetActive(false);
    }
}
