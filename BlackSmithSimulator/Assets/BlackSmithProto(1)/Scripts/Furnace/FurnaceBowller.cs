using UnityEngine.UI;
using UnityEngine;

public class FurnaceBowller : MonoBehaviour
{
    /*
    public Text pressure_Pump;
    float pressure = 0;
    float pump = 10;

    // Update is called once per frame
    void Update()
    {
        pressure_Pump.text = "Pressure:" + pressure;

        if (pressure >= 0)
        {
            pressure -= Time.deltaTime;
        }
        if (pressure <= 0)
        {
            pressure = 0;
        }
        if (pressure >= 100)
        {
            pressure = 100;
        }
    }
    public void Pumper()
    {
        pressure += pump;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Ore")
        {
            if (other.GetComponent<Ore>().material_Ore == 1)
            {
                if (pressure >= 20 && pressure <= 50)
                {
                    other.GetComponent<Ore>().cook_Time -= Time.deltaTime;
                    if (other.GetComponent<Ore>().cook_Time <= 0)
                    {
                        other.GetComponent<Ore>().current_Stage = 2;
                        print("Stage1Done");
                    }
                }
            }
            if (other.GetComponent<Ore>().material_Ore == 2)
            {
                if (pressure >= 30 && pressure <= 60)
                {
                    other.GetComponent<Ore>().cook_Time -= Time.deltaTime;
                    if (other.GetComponent<Ore>().cook_Time <= 0)
                    {
                        other.GetComponent<Ore>().current_Stage = 2;
                        print("Stage1Done");
                    }
                }
            }
            if (other.GetComponent<Ore>().material_Ore == 3)
            {
                if (pressure >= 10 && pressure <= 40)
                {
                    other.GetComponent<Ore>().cook_Time -= Time.deltaTime;
                    if (other.GetComponent<Ore>().cook_Time <= 0)
                    {
                        other.GetComponent<Ore>().current_Stage = 2;
                        print("Stage1Done");
                    }
                }
            }
            if (other.GetComponent<Ore>().material_Ore == 4)
            {
                if (pressure >= 60 && pressure <= 90)
                {
                    other.GetComponent<Ore>().cook_Time -= Time.deltaTime;
                    if (other.GetComponent<Ore>().cook_Time <= 0)
                    {
                        other.GetComponent<Ore>().current_Stage = 2;
                        print("Stage1Done");
                    }
                }
            }
        }
    }
    */
}
