using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private Platform platform;
    [SerializeField] private Actor myActor;
    private float platformX;
    private float platformZ;
    private float beginX;
    private float beginY;
    private float beginZ;

    private Transform selectedTransform;
    [SerializeField] private float heightOffset = 1;
    [SerializeField] private float desiredHeightOnPlatform = 1.9f;
    private bool hasPlatform = false;

    private void Start()
    {
        beginX = transform.position.x;
        beginY = transform.position.y;
        beginZ = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    { 
        NewDragAndDrop();
    }

    private void CheckForPlatform()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -Vector3.up, out hit, 5f);
        //if (hit.collider != null)
        if (hit.collider.CompareTag("platform"))
        {
            Debug.Log("Platform is underneath me");
            hasPlatform = true;   
        }
        else
        {
            hasPlatform = false;
        }

        if (hasPlatform)
        {
            platform = hit.collider.gameObject.GetComponent<Platform>();
            platform.isChosen = true;
            
            platformX = platform.transform.position.x;
            platformZ = platform.transform.position.z;
        }
        else if (platform != null)
        {
            platform.isChosen = false;
            platform.OnActorPickedUp(selectedTransform);
            platform = null;
        }

        Debug.DrawRay(transform.position, -Vector3.up * 5f, Color.green);
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
                    selectedTransform = hit.collider.transform;
                    //Set object to ignore raycast layer
                    selectedTransform.gameObject.layer = 2;
                    
                }
                else if (hasPlatform)
                {
                    platform.OnActorPlaced(myActor, selectedTransform);
                    selectedTransform.position = new Vector3(platformX, desiredHeightOnPlatform, platformZ);
                    selectedTransform.gameObject.layer = 0;
                    selectedTransform = null;
                }
                else
                {
                    //if (platform != null)
                    //{
                    //    platform.OnActorPickedUp(selectedTransform);
                    //}
                    selectedTransform.position = new Vector3(beginX, beginY, beginZ);
                    selectedTransform.gameObject.layer = 0;
                    selectedTransform = null;
                    
                }

            }

            if (selectedTransform != null)
            {
                selectedTransform.position = hit.point;
                selectedTransform.position = new Vector3(selectedTransform.position.x, selectedTransform.position.y + heightOffset, selectedTransform.position.z);
                CheckForPlatform();
            }

        }
    }
}
