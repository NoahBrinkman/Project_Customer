using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isChosen = false;
   
    public Actor occupiedBy = Actor.empty;
    
    private Transform lookAtTarget;
    // Start is called before the first frame update
    void Start()
    {
        lookAtTarget = transform.parent.GetComponent<Transform>();
    }


    public void OnActorPlaced(Actor actor, Transform actorTransform)
    {
        occupiedBy = actor;
        actorTransform.LookAt(lookAtTarget, Vector3.up);
        actorTransform.parent = transform;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColour();
        isChosen = false;
        
    }

    private void ChangeColour()
    {
        if (isChosen)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    
    
}
