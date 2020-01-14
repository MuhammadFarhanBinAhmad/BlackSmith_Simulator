using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public GameObject glowing_Object;

    private void Start()
    {
        glowing_Object.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name =="Hand")
        {
            glowing_Object.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Hand")
        {
            glowing_Object.SetActive(false);
        }
    }
}
