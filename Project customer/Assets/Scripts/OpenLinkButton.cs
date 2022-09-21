using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinkButton : MonoBehaviour
{
    public void OpenLink()
    {
        Debug.Log("s");
        System.Diagnostics.Process.Start("https://jigsaw.google.com/the-current/disinformation/");
    }
}
