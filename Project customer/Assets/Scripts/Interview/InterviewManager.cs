using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestionAndAnswerDialogue
{
    public string question;
    [TextArea] public string response;
}
[Serializable]
public class InteriewSubject
{
    public Actor actor;
    public List<QuestionAndAnswerDialogue> AnswerDialogues;
}

public class InterviewManager : MonoBehaviour
{
    public static InterviewManager Instance { get; private set; }

    public List<InteriewSubject> subjects = new List<InteriewSubject>();
    public Actor currentlySelected = Actor.empty;
    private void Awake() 
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(gameObject); 
        } 
        else 
        { 
            Instance = this; 
            DontDestroyOnLoad(this);
        } 
    }

    public void GoToInterviewScene(Actor actor)
    {
        SceneTransitionManager.Instance.LoadSceneTransition(3);
        currentlySelected = actor;
    }
    
    
}
