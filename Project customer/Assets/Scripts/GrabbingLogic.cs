using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingLogic : MonoBehaviour
{
    private Transform selectedTransform;
    [SerializeField] private float heightOffset = 1;
    private StageSpot platform;
    private Puppet puppet;
    private bool hasPlatform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();   
    }
    private void DragAndDrop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //Debug.Log(hit.collider.name);
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.GetComponent<Puppet>())
                {
                    Debug.Log("Puppet grabbed");
                    puppet = hit.collider.gameObject.GetComponent<Puppet>();            //Assing the Puppet object to get variables like start position
                    selectedTransform = puppet.transform;
                    selectedTransform.gameObject.layer = 2;                             //Set object to ignore raycast layer

                    //Removing actor from the spot when moved
                    if (platform != null)
                    {
                        platform.occupiedBy = Actor.empty;
                    }

                }
                else if (hasPlatform && selectedTransform != null)
                {
                    PlaceOnThePlatform();
                }
                else if (selectedTransform != null)
                {
                    //Drop the puppet back to the chest - so move it to its start position
                    Debug.Log("Going back to the chest");
                    selectedTransform.position = puppet.startPosition;
                    selectedTransform.gameObject.layer = 0;
                    selectedTransform = null;
                }

            }
            //Move object around
            if (selectedTransform != null)
            {
                selectedTransform.position = hit.point;
                selectedTransform.position = new Vector3(
                    selectedTransform.position.x, 
                    selectedTransform.position.y + heightOffset,
                    selectedTransform.position.z);
                CheckForPlatform();
            }

        }
    }

    private void CheckForPlatform()
    {
        RaycastHit hit;
        Physics.Raycast(selectedTransform.position, Vector3.down, out hit);
        Debug.DrawRay(selectedTransform.position, -Vector3.up * 5f, Color.green);
        //Debug.Log(hit.transform.name);
        if (hit.transform.GetComponent<StageSpot>() && selectedTransform.gameObject.layer == 2)
        {
            platform = hit.transform.GetComponent<StageSpot>();
            platform.hoveredOver = true;                                                //Used for changing colour of the platform when hovered over - to show player which platform is chosen at the moment
            hasPlatform = true;                                                         //Used to determine if the puppet is already standing on the platform (used so we can have all the mouse clicking in drag and drop method)
        }
        else
        {
            hasPlatform = false;
        }
    }

    //Place the puppet on the spot
    private void PlaceOnThePlatform()
    {
        selectedTransform.parent = platform.transform;
        selectedTransform.localPosition = new Vector3(0, heightOffset, 0);
        selectedTransform.LookAt(platform.lookAtTarget, Vector3.up);
        platform.occupiedBy = selectedTransform.GetComponent<Puppet>().actor;
        selectedTransform.gameObject.layer = 0;                                         //Used if we want to move around actors after they've been already placed on the spot (for example: if you placed the actor on the spot 15 by accident and you want it on spot 14)
        selectedTransform = null;
    }
}
