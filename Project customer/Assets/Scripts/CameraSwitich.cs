using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraSwitich : MonoBehaviour
{
    [SerializeField] private float zoomedInFew = 18;
    [SerializeField] private float zoomedOutFew = 60;
    private float fov;
    private Camera cam;
    private bool zooming = false;
    private bool zoomingIn = true;
    [SerializeField] private float time;
    private float timer = 0;

    [SerializeField] private List<float> lookRotations;
    private bool rotating = false;
    [SerializeField] private float rotationTime = .5f;
    private float rotationTimer = 0;
    private float rotationY;
    private int index = 0;

    private float startRotation;
    private bool firstActivation = true;
    private bool finished = false;


    public UnityEvent OnCameraSwitched;
    
    private void Start()
    {
        cam = GetComponent<Camera>();
        fov = zoomedOutFew;
        rotationY = transform.rotation.y;
        startRotation = transform.rotation.y;
    }

    private void Update()
    {
        if (finished)
        {
            MoveToFinalScene();
            return;
        }
        if (zooming)
        {
            timer += Time.deltaTime;
            if(zoomingIn)
                fov = Mathf.Lerp(fov, zoomedInFew, timer / time);
            else
            {
                fov = Mathf.Lerp(fov, zoomedOutFew, timer / time);
            }
            cam.fieldOfView = fov;
            if (timer >= time)
            {
                zooming = false;
                zoomingIn = !zoomingIn;
                if (zoomingIn)
                {
                    rotating = true;
                }
                else
                {
                    OnCameraSwitched?.Invoke();
                }
                timer = 0;
            }
        }
        
        //cycle through look rotations and lerp em
        if (rotating)
        {
            rotationTimer += Time.deltaTime;
            Vector3 currentRotation = transform.eulerAngles;
             currentRotation.y = Mathf.Lerp (currentRotation.y, lookRotations[index], rotationTimer/rotationTime);
             transform.eulerAngles = currentRotation;
            if (rotationTimer >= rotationTime)
            {
                rotating = false;
                rotationTimer = 0;
                rotationY = transform.rotation.y;
                if (index != lookRotations.Count - 1)
                {
                    zooming = true;
                }
                else
                {
                    finished = true;
                }
                
                if (index + 1 < lookRotations.Count)
                {
                    index++;
                }
                else
                {
                    index = 0;
                    OnCameraSwitched.AddListener(MoveToFinalScene);
                }
            }
        }
        
        
    }
    private void MoveToFinalScene()
    {
        SceneTransitionManager.Instance.LoadSceneTransition(5);
    }
    public void NextSpot()
    {
        if (firstActivation)
        {
            rotating = true;
            firstActivation = false;
        }
        else
        {
            zooming = true; 
        }
    }
}
