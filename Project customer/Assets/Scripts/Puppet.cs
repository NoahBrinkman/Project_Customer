using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puppet : MonoBehaviour
{
    [HideInInspector] public Vector3 startPosition;
    public Actor actor = Actor.empty;
    public List<StageSpot> stageSpots;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }



}
