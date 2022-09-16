using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Clipboard : MonoBehaviour
{
    private float baseHeight;
   [SerializeField] private float hoverHeight;
    [SerializeField] private float clickedHeight;
    private Button button;
    private RectTransform rTransform;
    private bool isUp;
    
    private void Start()
    {
       
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
        rTransform = GetComponent<RectTransform>();
        baseHeight = rTransform.position.y;
    }

    private void OnClick()
    {
        if (!isUp)
        { 
            rTransform.position = new Vector3(rTransform.position.x, clickedHeight, 
                rTransform.position.z);
            isUp = true;
        }
        else
        {
            rTransform.position = new Vector3(rTransform.position.x, baseHeight, 
                rTransform.position.z);
            isUp = false;
        }
       
        

    }

}

