using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool isChosen = false;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeColour();
        isChosen = false;
        
    }

    private void ChangeColour()
    {
        if (isChosen)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

    
    
}
