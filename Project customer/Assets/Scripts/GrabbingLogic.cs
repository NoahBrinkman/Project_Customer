using UnityEngine;

public class GrabbingLogic : MonoBehaviour
{
    public SpotlightFollow spotlight;

    [SerializeField] private float heightOffset = 1;

    private Transform selectedTransform;
    private StageSpot stageSpot;
    private GrabbableActor actor;

    private bool hasStageSpot;
    private bool actorHovered;

    private bool actorGrabbed;
    // Start is called before the first frame update
    void Start()
    {
        spotlight = gameObject.GetComponentInChildren<SpotlightFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
            DragAndDrop();
            if (hasStageSpot && !actorHovered)
            {

                spotlight.transform.LookAt(stageSpot.transform);
                spotlight.turnedOn = true;
            }
            else if (!actorHovered)
            {
                spotlight.turnedOn = false;
            }
        
        
    }

    /// <summary>
    /// Method responsible for dragging and dropping the Actor on the StageSpot
    /// </summary>
    private void DragAndDrop()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            //Show the spotlight on the Actor that the mouse is hovered over
            if (hit.collider.gameObject.GetComponent<GrabbableActor>())
            {
                actorHovered = true;
                if(!actorGrabbed)
                    spotlight.transform.LookAt(hit.transform);
                
                spotlight.turnedOn = true;
                //Debug.Log("Puppet found");
            }

            //Righclick responsible for interaction with objects
            if (Input.GetMouseButtonDown(1) && !actorGrabbed)
            {
                if (hit.collider.gameObject.GetComponent<GrabbableActor>())
                {
                    InterviewManager.Instance.GoToInterviewScene(hit.collider.GetComponent<GrabbableActor>().actor);
                }


            }

            //Leftclick responsible for dragging and dropping
            if (Input.GetMouseButtonDown(0) )
            {
                if (hit.collider.GetComponent<Book>() is Book book && !actorGrabbed)
                {
                    if (book != null) book.OnClick();
                }
                //Dragging the Actor
                if (hit.collider.gameObject.GetComponent<GrabbableActor>() && !hit.collider.gameObject.GetComponent<GrabbableActor>().isManager && !actorGrabbed)
                {
                    actorHovered = false;
                    actor = hit.collider.gameObject.GetComponent<GrabbableActor>();            //Assing the Puppet object to get variables like start position
                    selectedTransform = actor.transform;
                    selectedTransform.gameObject.layer = 2;                                     //Set object to ignore raycast layer 
                    actorGrabbed = true;
                }
                //Placing the Actor on the StageSpot
                else if (hasStageSpot && selectedTransform != null)
                {
                    PlaceOnThePlatform();
                }
                //Teleporting the Actor back to its start position
                else if (selectedTransform != null)
                {
                    selectedTransform.position = actor.startPosition;
                    selectedTransform.gameObject.layer = 0;
                    selectedTransform = null;
                    actorGrabbed = false;
                    //Debug.Log("Going back to the chest");
                }
            }

            //Move object around after click on it
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

    /// <summary>
    /// Method responsible for checking if Actor is above the StageSpot
    /// </summary>
    private void CheckForPlatform()
    {
        Physics.Raycast(selectedTransform.position, Vector3.down, out RaycastHit hit);
        Debug.DrawRay(selectedTransform.position, -Vector3.up * 5f, Color.green);
        //Debug.Log(hit.transform.name);
        if (hit.transform.GetComponent<StageSpot>() && selectedTransform.gameObject.layer == 2)
        {
            stageSpot = hit.transform.GetComponent<StageSpot>();
            stageSpot.hoveredOver = true;
            hasStageSpot = true;
        }
        else
        {
            hasStageSpot = false;
        }
    }

    //Place the puppet on the spot
    private void PlaceOnThePlatform()
    {
        if(stageSpot.occupiedBy != Actor.empty) return;
        AudioManager.Instance.PlaySound("Confirm");
        selectedTransform.parent = stageSpot.transform;
        selectedTransform.localPosition = new Vector3(0, 0.45f, 0);
        selectedTransform.LookAt(new Vector3(stageSpot.lookAtTarget.position.x, selectedTransform.position.y, stageSpot.lookAtTarget.position.z), Vector3.up);
        stageSpot.occupiedBy = selectedTransform.GetComponent<GrabbableActor>().actor;
        selectedTransform.gameObject.layer = 0;                                         //Used if we want to move around actors after they've been already placed on the spot (for example: if you placed the actor on the spot 15 by accident and you want it on spot 14)
        selectedTransform = null;
        hasStageSpot = false;
        actorGrabbed = false;
    }

    private void TurnTheLights(RaycastHit hit)
    {
    }
}