using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] private GameObject bookUI;
    public void OnClick()
    {
        bookUI.SetActive(!bookUI.activeSelf);
        GetComponent<BoxCollider>().enabled = !GetComponent<BoxCollider>().enabled;
    }
}
