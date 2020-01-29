using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{


    public float min_X;
    public float max_X;

    public float min_Y;
    public float max_Y;

    public float min_Z;
    public float max_Z;

    public float min_Intensity;
    public float max_Intensity;

    float x_Rotation_Over_Time;
    float y_Rotation_Over_Time;
    float z_Rotation_Over_Time;
    float light_Intensity_Over_Time;


    // Update is called once per frame
    void Update()
    {

        x_Rotation_Over_Time = (-(max_X - min_X) / 100) * Time.deltaTime;
        y_Rotation_Over_Time = (-(max_Y - min_Y) / 100) * Time.deltaTime;
        z_Rotation_Over_Time = ((max_Z - min_Z) / 100) * Time.deltaTime;
        light_Intensity_Over_Time = (max_Intensity - min_Intensity / 100);

        if (CustomerSpawner.Customer_Already_Serve == 0)
        {
            if (transform.localEulerAngles.x >= min_X + ((max_X - min_X )/ 2))
            {
                TheSunRotation();
            }
        }
        else if (CustomerSpawner.Customer_Already_Serve == 1)
        {
            if (transform.localEulerAngles.x >= min_X)
            {
                TheSunRotation();
            }
        }
    }
        
    void TheSunRotation()
    {

        Color start = new Color(1, 0.9241f, 0.8066f);
        Color end = new Color(.849f, .4274f, .1802f);

        transform.Rotate(x_Rotation_Over_Time, y_Rotation_Over_Time, z_Rotation_Over_Time);
        GetComponent<Light>().intensity = min_Intensity + light_Intensity_Over_Time * (Time.time / 250);
        GetComponent<Light>().color = Color.Lerp(start, end, (Time.time / 50));
    }
}
