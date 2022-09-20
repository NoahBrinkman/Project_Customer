using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class ActorWithPrefab
{
    public Actor Actor;
    public GameObject prefab;
}

public class EndStage : MonoBehaviour
{
    [SerializeField] private List<ActorWithPrefab> actors = new List<ActorWithPrefab>();
    Dictionary<Actor, GameObject> dictionary = new Dictionary<Actor, GameObject>();
    [SerializeField] private List<EndStageSpot> spots;
    [SerializeField] private List<SpotlightFollow> spotlights;
    [SerializeField] private CameraSwitich switcher;
    private bool lightGreen = false;
    private int index = 0;
    private void Start()
    {
        for (int i = 0; i < actors.Count; i++)
        {
            dictionary.Add(actors[i].Actor, actors[i].prefab);
        }

        List<ActorSelection> selection = new List<ActorSelection>();

        SelectionPasser passer = SelectionPasser.Instance;
        selection = passer.selection;
        for (int i = 0; i < selection.Count; i++)
        {
            GameObject g = GameObject.Instantiate(dictionary[selection[i].actor], spots[i].transform);
            spots[i].occupiedBy = selection[i].actor;
            spots[i].correct = selection[i].correct;
            lightGreen = selection[i].correct;
            spotlights[i].endLight = true;
            spotlights[i].greenLight = selection[i].correct;
            g.transform.localPosition = new Vector3(0, .5f, 0);

        }
        for (int i = 0; i < spots.Count; i++)
        {
            spots[i].Deactivate();
        }
        switcher.NextSpot();
        switcher.OnCameraSwitched.AddListener(ActivateNewDialogue);
        
    }

    private void ActivateNewDialogue()
    {

        spots[index].Activate();
    }

    public void OnConversationComplete()
    {
        spots[index].Deactivate();
        if (index + 1 < spots.Count)
        {
            
            index++;
        }
        switcher.NextSpot();
    }
    
}
