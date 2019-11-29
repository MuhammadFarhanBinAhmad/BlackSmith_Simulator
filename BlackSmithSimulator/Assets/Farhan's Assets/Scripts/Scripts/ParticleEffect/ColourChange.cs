using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{

    ParticleSystem the_Particle_System;
    Color r;
    public float test;
    float t;

    float new_Intensity;

    // Start is called before the first frame update
    void Start()
    {
        the_Particle_System = GetComponent<ParticleSystem>();
    }
    private void Update()
    {
        var col = the_Particle_System.colorOverLifetime;//set colour overlifetime value

        Gradient grad = new Gradient();


        r = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));

        //r = Color.Lerp(Color.red,Color.black,Mathf.PingPong(Time.time , 1))

        col.enabled = true;
        grad.SetKeys
            (new GradientColorKey[]
            {  new GradientColorKey(r, 0f)}//handle color
            ,
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f)});//handle alpha
        col.color = grad;
    }
}
