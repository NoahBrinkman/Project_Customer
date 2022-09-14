using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selected;
    public GameObject spriteObject;
    private Platform platform;
    [SerializeField] private Actor myActor;
    [SerializeField] private float heightOfPickup = 0.8f;
    [SerializeField] private float heightOfPlatform = 1.05f;
    [SerializeField] private float desiredScale = 1.5f;
    private float platformX;
    private float platformZ;
    private float beginX;
    private float beginY;
    private float beginZ;

    private void Start()
    {
        beginX = transform.position.x;
        beginY = transform.position.y;
        beginZ = transform.position.z;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(selected == null)                //if there's no object selected
            {
                RaycastHit hit = CastRay();

                if(hit.collider != null)        //react only if an object has a collider
                {
                    if (!hit.collider.CompareTag("drag"))
                    {
                        return;                 //if the oobject is not dragable
                    }

                    selected = hit.collider.gameObject;
                    //Cursor.visible = false;
                }
            }
            else
            {
                DragAndDrop(heightOfPlatform, false);
                spriteObject.transform.localScale=new Vector3(1, 1, 1);
                selected = null;
            }
        }

        if (selected != null)
        {
            DragAndDrop(heightOfPickup, true);
            CheckForPlatform();
            spriteObject.transform.localScale = new Vector3(desiredScale, desiredScale, desiredScale);
        }
        
    }

    private void CheckForPlatform()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, -Vector3.up, out hit, 5f);
        if (hit.collider != null)
        if (hit.collider.CompareTag("platform"))
        {
                Debug.Log("Platform is underneath me");
                Debug.Log(hit.collider.gameObject.name);
                platform = hit.collider.gameObject.GetComponent<Platform>();
                platform.isChosen = true;
                platformX = platform.transform.position.x;
                platformZ = platform.transform.position.z;
        }

        Debug.DrawRay(transform.position, -Vector3.up * 5f, Color.green);
    }

    private RaycastHit CastRay()
    {
        Vector3 screenMousePositionFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);      //farClipPlane - futhest point for the camera to see
        Vector3 screenMousePositionNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);
        Vector3 worldMousePositionFar = Camera.main.ScreenToWorldPoint(screenMousePositionFar);
        Vector3 worldMousePositionNear = Camera.main.ScreenToWorldPoint(screenMousePositionNear);
        RaycastHit hit;
        Physics.Raycast(worldMousePositionNear, worldMousePositionFar - worldMousePositionNear, out hit);

        return hit;
    }

    private void DragAndDrop(float height, bool pickup)
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selected.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        if (pickup)
        {
            selected.transform.position = new Vector3(worldPosition.x, height, worldPosition.z);
        }
        else if (!pickup && platform != null)
        {
            selected.transform.position = new Vector3(platformX, height, platformZ);
            platform.OnActorPlaced(myActor, selected.transform);
            
        }
        else
        {
            selected.transform.position = new Vector3(beginX, beginY, beginZ);
        }
        
    }
}
