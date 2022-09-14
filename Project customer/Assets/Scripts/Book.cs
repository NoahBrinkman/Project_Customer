using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private GameObject bookUI;
    public void OnClick()
    {
        Debug.Log("Book OPENED");
        bookUI.SetActive(!bookUI.activeSelf);
        
    }
}
