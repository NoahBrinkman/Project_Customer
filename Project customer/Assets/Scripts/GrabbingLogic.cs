using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingLogic : MonoBehaviour
{
    private Transform selectedTransform;
    [SerializeField] private float heightOffset = 1;
    private StageSpot platform;
    private Puppet puppet;
    public SpotlightFollow spotlight;
    private bool hasPlatform;
    private bool hasPuppet;

    // Start is called before the first frame update
    void Start()
    {
        spotlight = gameObject.GetComponentInChildren<SpotlightFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        DragAndDrop();
        if (hasPlatform && !hasPuppet)
        {
            spotlight.transform.LookAt(platform.transform);
            spotlight.turnedOn = true;
        }
        else if (!hasPuppet)
        {
            spotlight.turnedOn = false;
        }


    }
    private void DragAndDrop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.GetComponent<Puppet>())
            {
                hasPuppet = true;
                Debug.Log("Puppet found");
                spotlight.transform.LookAt(hit.transform);
                spotlight.turnedOn = true;
            }
            //Debug.Log(hit.collider.name);
            if (Input.GetMouseButtonDown(1))
            {
                if (hit.collider.gameObject.GetComponent<Puppet>())
                {
                    InterviewManager.Instance.GoToInterviewScene(hit.collider.GetComponent<Puppet>().actor);
                }
                if (hit.collider.GetComponent<Book>() is Book book)
                {
                    if (book != null) book.OnClick();
                }

            }

            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject.GetComponent<Puppet>())
                {
                    hasPuppet = false;
                    puppet = hit.collider.gameObject.GetComponent<Puppet>();            //Assing the Puppet object to get variables like start position
                    selectedTransform = puppet.transform;
                    selectedTransform.gameObject.layer = 2;                             //Set object to ignore raycast layer 
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
        selectedTransform.LookAt(new Vector3(platform.lookAtTarget.position.x, selectedTransform.position.y, platform.lookAtTarget.position.z), Vector3.up);
        platform.occupiedBy = selectedTransform.GetComponent<Puppet>().actor;
        selectedTransform.gameObject.layer = 0;                                         //Used if we want to move around actors after they've been already placed on the spot (for example: if you placed the actor on the spot 15 by accident and you want it on spot 14)
        selectedTransform = null;
        hasPlatform = false;
    }
}
