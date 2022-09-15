using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{

    private Transform selectedTransform;
    [SerializeField] private float heightOffset = 1;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out RaycastHit hit))
        {
            //Debug.Log(hit.collider.name);
            if (selectedTransform == null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.GetComponent<DragableObject>())
                    {
                        selectedTransform = hit.collider.transform;
                        //Set object to ignore raycast layer
                        selectedTransform.gameObject.layer = 2;
                    }
                    else if (hit.collider.GetComponent<Book>() is Book book)
                    {
                        if(book != null) book.OnClick();
                    }
                }
            }

            if (selectedTransform != null)
            {
                selectedTransform.position = hit.point;
                selectedTransform.position = new Vector3(selectedTransform.position.x, selectedTransform.position.y +heightOffset,
                    selectedTransform.position.z);
              
                if (Physics.Raycast(new Vector3(hit.point.x,hit.point.y+1,hit.point.z), Vector3.down, out RaycastHit platformHit))
                {
                    Debug.DrawRay(new Vector3(hit.point.x,hit.point.y+1,hit.point.z), Vector3.down);
                    Debug.Log(platformHit.transform.name);
                    if (platformHit.transform.GetComponent<StageSpot>())
                    {
                        Debug.Log("platformHit");
                        if (Input.GetMouseButtonDown(0))
                        {
                            StageSpot platform = platformHit.transform.GetComponent<StageSpot>();
                            selectedTransform.parent = platform.transform;
                            selectedTransform.localPosition = new Vector3(0,heightOffset,0);
                            selectedTransform.LookAt(platform.lookAtTarget, Vector3.up);
                            platform.occupiedBy = selectedTransform.GetComponent<DragableObject>().actor;
                            selectedTransform = null;
                        }
                    }
                }
            }

        }
    

        
    }
}
