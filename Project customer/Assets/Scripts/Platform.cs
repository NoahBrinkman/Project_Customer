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
        Debug.Log(occupiedBy);
        actorTransform.LookAt(lookAtTarget, Vector3.up);
        actorTransform.parent = transform;
    }

    public void OnActorPickedUp(Transform actorTransform)
    {
        occupiedBy = Actor.empty;
        actorTransform.rotation = new Quaternion(0, 0, 0,0);
        //isChosen = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColour();
        
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
