using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFeedback : MonoBehaviour
{
    public SpotlightFollow spotlight;
    public GameObject bookPart;
    public GameObject mainPage;
    void Start()
    {
        spotlight = gameObject.GetComponentInChildren<SpotlightFollow>();
        spotlight.transform.LookAt(bookPart.transform);
        
    }

    void Update()
    {
        HoverOver();
    }

    public void HoverOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            FeedbackOne(hit);
            //FeedbackTwo(hit);
        }

        Debug.Log(spotlight.turnedOn);
    }

    private void FeedbackOne(RaycastHit hit)
    {
        if (hit.collider.gameObject.GetComponent<Book>())
        {
            Debug.Log("I selected the book");
            spotlight.turnedOn = true;

        }
        else
        {
            spotlight.turnedOn = false;
        }
    }

    private void FeedbackTwo(RaycastHit hit)
    {
        if (hit.collider.gameObject.GetComponent<Book>())
        {
            Debug.Log("I selected the book");
            mainPage.GetComponent<Renderer>().material.color = Color.red;

        }
        else
        {
            mainPage.GetComponent<Renderer>().material.color = Color.grey;
        }
    }
}
