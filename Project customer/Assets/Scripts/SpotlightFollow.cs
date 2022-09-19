using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    public bool turnedOn = false;
    Light spotlight;
    // Start is called before the first frame update
    void Start()
    {
        spotlight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnedOn)
        {
            spotlight.enabled = true;
        }
        else
        {
            spotlight.enabled = false;
        }
    }
}
