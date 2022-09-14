using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingLogic : MonoBehaviour
{
    private Transform selectedTransform;
    [SerializeField] private float heightOffset = 1;
    [SerializeField] private float desiredHeightOnPlatform = 1.9f;
    private StageSpot platform;
    private Puppet puppet;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NewDragAndDrop();   
    }
    private void NewDragAndDrop()
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
                    //Assing the Puppet object to get variables like start position
                    puppet = hit.collider.gameObject.GetComponent<Puppet>();
                    selectedTransform = puppet.transform;
                    //Set object to ignore raycast layer
                    selectedTransform.gameObject.layer = 2;

                }
                else if (platform == null)
                {
                    //Drop the puppet back to the chest
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
            Debug.Log("Platform hit");
            Debug.Log(platform);
            platform = hit.transform.GetComponent<StageSpot>();
            platform.hoveredOver = true;
            if (Input.GetMouseButtonDown(0))
            {
                selectedTransform.parent = platform.transform;
                selectedTransform.localPosition = new Vector3(0, heightOffset, 0);
                selectedTransform.LookAt(platform.lookAtTarget, Vector3.up);
                platform.occupiedBy = selectedTransform.GetComponent<Puppet>().actor;
                selectedTransform.gameObject.layer = 0;
                selectedTransform = null;
                platform = null;
                
            }
        }
    }
}
