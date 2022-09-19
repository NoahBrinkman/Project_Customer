using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpot : MonoBehaviour
{
    public Actor occupiedBy = Actor.empty;
    public bool hoveredOver = false;
    public Transform lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
       // lookAtTarget = transform.parent.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
        // transform.LookAt(lookAtTarget,Vector3.up);
        //ChangeColour();
        hoveredOver = false;

        if (transform.childCount == 0)
        {
            occupiedBy = Actor.empty;
        }
    }

    private void OnActorPlaced(Actor actor, Transform actorTransform)
    {
        occupiedBy = actor;
        actorTransform.LookAt(lookAtTarget, transform.up);
        actorTransform.parent = transform;
    }

    public void OnActorRemoved(Transform actorTransform)
    {
        occupiedBy = Actor.empty;
        actorTransform.rotation = new Quaternion(0, 0, 0,0);
    }

    private void ChangeColour()
    {
        if (hoveredOver)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

}
