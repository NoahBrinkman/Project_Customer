using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CloseBookButton : MonoBehaviour
{
    [SerializeField] private GameObject masterParent;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        masterParent.SetActive(false);
    }
    
}
