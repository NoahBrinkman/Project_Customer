using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for turning on the Spotlights and changing their colours
/// </summary>
public class SpotlightFollow : MonoBehaviour
{
    public bool turnedOn = false;
    public bool endLight = false;
    public bool greenLight = false;

    private Light spotlight;

    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnedOn && !endLight)
        {
            spotlight.enabled = true;
        }
        else if (endLight)
        {
            spotlight.enabled = true;

            if (!greenLight)
            {
                spotlight.color = Color.red;
            }
            else
            {
                spotlight.color = Color.green;
            }

        }
        else
        {
            spotlight.enabled = false;
        }


    }

}
