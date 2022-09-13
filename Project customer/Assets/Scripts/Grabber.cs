using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabber : MonoBehaviour
{
    private GameObject selected;
    public float heightOfPickup = 0.8f;
    public float heightOfPlatform = 1.05f;

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
                DragAndDrop(heightOfPlatform);

                selected = null;
            }
        }

        if (selected != null)
        {
            DragAndDrop(heightOfPickup);
        }
        
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

    private void DragAndDrop(float height)
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selected.transform.position).z);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);
        selected.transform.position = new Vector3(worldPosition.x, height, worldPosition.z);
    }
}
