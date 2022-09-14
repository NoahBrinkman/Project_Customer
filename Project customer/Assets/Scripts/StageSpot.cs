using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpot : MonoBehaviour
{
    public Actor occupiedBy = Actor.empty;
    
    private Transform lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
        lookAtTarget = transform.parent.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.LookAt(lookAtTarget,Vector3.up);
    }

    private void OnActorPlaced(Actor actor, Transform actorTransform)
    {
        occupiedBy = actor;
        actorTransform.LookAt(lookAtTarget, transform.up);
        actorTransform.parent = transform;
    }
    
}
