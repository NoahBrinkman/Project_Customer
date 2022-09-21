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


    [SerializeField] private int endSceneBuildIndex = 3;

   
    
    public void OnDirectButtonClicked()
    {
        List<Actor> actorsInField = new List<Actor>();
        for (int i = 0; i < spots.Count; i++)
        {
            actorsInField.Add(spots[i].occupiedBy);
        }

        List<ActorSelection> selection = new List<ActorSelection>();
        
        if (actorsInField.All(x => correctScene.actorScene.actors.Contains(x)))
        {
            Debug.Log("all correct");
            for (int i = 0; i < actorsInField.Count; i++)
            {
                selection.Add(new ActorSelection(actorsInField[i],true));
            }
        }
        else
        {
            for (int i = 0; i < actorsInField.Count; i++)
            {
                if (correctScene.actorScene.actors.Contains(actorsInField[i]))
                {
                    Debug.Log($"Index of actors in scene: {i} Matches");
                    selection.Add(new ActorSelection(actorsInField[i],true));
                }
                else
                {
                    selection.Add( new ActorSelection(actorsInField[i], false));
                    Debug.Log("Wrong");
                }
            }
        }

        SelectionPasser.Instance.selection = selection;
        SceneTransitionManager.Instance.LoadSceneTransition(endSceneBuildIndex);
    }
    

    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z),new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z));
        Gizmos.DrawLine(new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z), new Vector3(transform.forward.x - .2f, transform.forward.y + .5f, transform.forward.z - .2f));
        Gizmos.DrawLine(new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z), new Vector3(transform.forward.x + .2f, transform.forward.y + .5f, transform.forward.z - .2f));
    }
}

public class ActorSelection
{

    public Actor actor;
    public bool correct;
    
    public ActorSelection(Actor actor, bool correct)
    {
        this.actor = actor;
        this.correct = correct;
    }
    
}
