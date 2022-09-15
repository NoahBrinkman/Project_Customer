using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage : MonoBehaviour
{
    [SerializeField] private List<StageScene> scenes = new List<StageScene>();

    [SerializeField] private List<StageSpot> spots = new List<StageSpot>();

    [SerializeField] private int correctSceneBuildIndex;
    [SerializeField] private int incorrectSceneBuildIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnDirectButtonClicked()
    {
        StageScene scene = AnyScenesMatch();
        if (scene != null)
        {
            if (scene.correct)
            {
                Debug.Log("correct");
                SceneTransitionManager.Instance.LoadSceneTransition(correctSceneBuildIndex);
            }
            else
            {
                Debug.Log("Incorrect");
                SceneTransitionManager.Instance.LoadSceneTransition(incorrectSceneBuildIndex);
            }
        }
    }
    
    private StageScene AnyScenesMatch()
    {
        List<Actor> actorsInField = new List<Actor>();
        for (int i = 0; i < spots.Count; i++)
        {
            actorsInField.Add(spots[i].occupiedBy);
        }

        for (int j = 0; j < scenes.Count; j++)
        {
            
            if (scenes[j].actorScene.actors.All(actorsInField.Contains))
            {
                return scenes[j];
            }
        }
        return null;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z),new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z));
        Gizmos.DrawLine(new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z), new Vector3(transform.forward.x - .2f, transform.forward.y + .5f, transform.forward.z - .2f));
        Gizmos.DrawLine(new Vector3(transform.forward.x, transform.forward.y + .5f, transform.forward.z), new Vector3(transform.forward.x + .2f, transform.forward.y + .5f, transform.forward.z - .2f));
    }
}
