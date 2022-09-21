using UnityEngine;

/// <summary>
/// Class responsible for feedback for the Book object
/// </summary>
public class BookFeedback : MonoBehaviour
{
    public SpotlightFollow spotlight;
    public GameObject bookPart;

    void Start()
    {
        spotlight = gameObject.GetComponentInChildren<SpotlightFollow>();
        spotlight.transform.LookAt(bookPart.transform); 
    }

    void Update()
    {
        HoverOver();
    }

    /// <summary>
    /// Method to show the spotlight after hovering over the book
    /// </summary>
    public void HoverOver()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.GetComponent<Book>())
            {
                Debug.Log("Book hovered");
                spotlight.turnedOn = true;
            }
            else
            {
                spotlight.turnedOn = false;
            }

        }
    }
}
