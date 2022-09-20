using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewSceneHandler : MonoBehaviour
{
    [SerializeField] private List<ActorWithPrefab> props;
    [SerializeField] private DialogueManager dialogueManager;
    private void Start()
    {
        for (int i = 0; i < props.Count; i++)
        {
            if (props[i].Actor != InterviewManager.Instance.currentlySelected)
            {
                props[i].prefab.SetActive(false);
            }

        }
        dialogueManager.SelectConversation(InterviewManager.Instance.currentlySelected);
        dialogueManager.NextDialogue();
        dialogueManager.OnConversationComplete.AddListener(OnConversationComplete);
    }

    private void OnConversationComplete()
    {
        SceneTransitionManager.Instance.LoadSceneTransition(1);
    }
    
}
