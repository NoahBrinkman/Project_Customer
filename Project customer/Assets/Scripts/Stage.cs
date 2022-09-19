using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    [SerializeField] private StageScene correctScene;

    [SerializeField] private List<StageSpot> spots = new List<StageSpot>();

    
    [SerializeField] private int correctSceneBuildIndex;
    [SerializeField] private int incorrectSceneBuildIndex;
    

    public void OnDirectButtonClicked()
    {
        List<Actor> actorsInField = new List<Actor>();
        for (int i = 0; i < spots.Count; i++)
        {
            actorsInField.Add(spots[i].occupiedBy);
        }

        if (actorsInField.All(x => correctScene.actorScene.actors.Contains(x)))
        {
            Debug.Log("all correct");
        }
        else
        {
            for (int i = 0; i < actorsInField.Count; i++)
            {
                if (correctScene.actorScene.actors.Contains(actorsInField[i]))
                {
                    Debug.Log($"Index of actors in scene: {i} Matches");
                }
                else
                {
                    Debug.Log("Wrong");
                }
            }
        }
        
        
    }
    

    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z),new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z));
        Gizmos.DrawLine(new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z), new Vector3(transform.forward.x - .2f, transform.forward.y + .5f, transform.forward.z - .2f));
        Gizmos.DrawLine(new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z), new Vector3(transform.forward.x + .2f, transform.forward.y + .5f, transform.forward.z - .2f));
    }
}
