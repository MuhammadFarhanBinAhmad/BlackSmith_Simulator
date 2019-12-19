using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class FadeInFadeOutEffect : MonoBehaviour
{

    public bool fadeToBlack;

    Light lightReference;

    float lightRange;
    float lightRangeTemp;
    float lightRangeSpeed = 1;     //Currently not fixed do not change value

    float lightIntensity;
    float lightIntensityTemp;
    float lightIntensitySpeed = 1; //Currently not fixed do not change value

    public float fadeTime = 5f;
    float fadeTimeTemp;
    float percentToChange;
    


    // Start is called before the first frame update
    void Start()
    {
        lightReference = this.GetComponent<Light>();

        lightRange = lightReference.range;
        lightRangeTemp = lightRange;

        lightIntensity = lightReference.intensity;
        lightIntensityTemp = lightIntensity;

        fadeTimeTemp = fadeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            if (fadeTime > 0)
            {
                fadeTimeTemp -= Time.deltaTime;
                FadeToBlack(fadeTimeTemp);
            }
        }

    }

    void FadeToBlack(float timeLeft)
    {
        percentToChange = timeLeft / fadeTime;

        if (lightRangeSpeed < 0)
        {
            Mathf.Abs(lightRangeSpeed);
        }
        else if (lightRangeSpeed == 0)
        {
            lightRangeSpeed = 1;
        }
        lightRangeTemp = (percentToChange / lightRangeSpeed) * lightRange;
        lightReference.range = lightRangeTemp;


        if (lightIntensitySpeed < 0)
        {
            Mathf.Abs(lightIntensitySpeed);
        }
        else if (lightIntensitySpeed == 0)
        {
            lightIntensitySpeed = 1;
        }
        lightIntensityTemp = (percentToChange / lightIntensitySpeed) * lightIntensity;
        lightReference.intensity = lightIntensityTemp;
    }
}
