using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFollow : MonoBehaviour
{
    public bool turnedOn = false;
    Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turnedOn)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
    }
}
