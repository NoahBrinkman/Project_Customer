using UnityEngine;

/// <summary>
/// Class used to manage spots that Actors can be placed on
/// </summary>
public class StageSpot : MonoBehaviour
{
    public Actor occupiedBy = Actor.empty;
    public bool hoveredOver = false;
    public Transform lookAtTarget;

    // Update is called once per frame
    void Update()
    {
        hoveredOver = false;

        //Makes sure to free the spot when Actor is picked up from the spot
        if (transform.childCount == 0)
        {
            occupiedBy = Actor.empty;
        }
    }


    /// <summary>
    /// Debug method to check if the right spot is found
    /// </summary>
    private void ChangeColour()
    {
        if (hoveredOver)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.grey;
        }
    }

}
