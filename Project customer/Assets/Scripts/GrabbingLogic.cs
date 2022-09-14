using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingLogic : MonoBehaviour
{
    private Transform selectedTransform;
    [SerializeField] private float heightOffset = 1;
    [SerializeField] private float desiredHeightOnPlatform = 1.9f;
    private Platform platform;
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
                if (hit.collider.CompareTag("drag"))
                {
                    //Assing the Puppet object to get variables like start position
                    puppet = hit.collider.gameObject.GetComponent<Puppet>();
                    selectedTransform = puppet.transform;
                    //Set object to ignore raycast layer
                    selectedTransform.gameObject.layer = 2;

                }
                else
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
                selectedTransform.position = new Vector3(selectedTransform.position.x, selectedTransform.position.y + heightOffset, selectedTransform.position.z);
                CheckForPlatform();
            }

        }
    }

    private void CheckForPlatform()
    {
        RaycastHit hit;
        Physics.Raycast(selectedTransform.position, -Vector3.up, out hit, 5f);

        if (hit.collider.CompareTag("platform"))
        {
            platform = hit.collider.gameObject.GetComponent<Platform>();
            platform.isChosen = true;
        }
        else
        {
            if (platform != null)
            {
                platform.isChosen = false;
            }
            
        }

        Debug.DrawRay(selectedTransform.position, -Vector3.up * 5f, Color.green);
    }
}
