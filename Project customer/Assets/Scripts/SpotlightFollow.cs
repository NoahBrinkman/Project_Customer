using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    public bool turnedOn = false;
    public bool endLight = false;
    public bool greenLight = false;
    Light spotlight;
    // Start is called before the first frame update
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
        else
        {
            spotlight.enabled = false;
        }

        if (endLight)
        {
            spotlight.enabled = true;
            if (endLight)
            {
                if (!greenLight)
                {
                    spotlight.color = Color.red;
                }
                else
                {
                    spotlight.color = Color.green;
                }
            }
        }
    }

}
