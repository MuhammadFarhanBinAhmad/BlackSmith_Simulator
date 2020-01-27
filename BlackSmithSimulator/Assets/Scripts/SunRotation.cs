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

    // Update is called once per frame
    void Update()
    {

        float x_Rotation_Over_Time = (-(max_X - min_X) / 100) * Time.deltaTime;
        float y_Rotation_Over_Time = (-(max_Y - min_Y) / 100) * Time.deltaTime;
        float z_Rotation_Over_Time = ((max_Z - min_Z) / 100) * Time.deltaTime;

        Color start = new Color(1,0.9241f,0.8066f);
        Color end = new Color(.849f, .4274f, .1802f);

        GetComponent<Light>().color = Color.Lerp(start, end, Mathf.PingPong(Time.time, .1f));


        if (transform.localEulerAngles.x >= min_X)
        {
            transform.Rotate(x_Rotation_Over_Time, y_Rotation_Over_Time, z_Rotation_Over_Time);


        }
    }
        

}
