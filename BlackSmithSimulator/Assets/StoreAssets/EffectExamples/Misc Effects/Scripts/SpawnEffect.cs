﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEffect : MonoBehaviour {

    public float spawnEffectTime = 2;
    public AnimationCurve fadeIn;

    //ParticleSystem ps;
    float timer = 0;
    Renderer _renderer;

    int shaderProperty;

	void Start ()
    {
        shaderProperty = Shader.PropertyToID("_cutoff");
        _renderer = GetComponent<Renderer>();

    }
	
	void Update ()
    {
        if (timer <= spawnEffectTime)
        {
            timer += Time.deltaTime;

        }
        _renderer.material.SetFloat(shaderProperty, fadeIn.Evaluate( Mathf.InverseLerp(0, spawnEffectTime, timer)));
        
    }
}
