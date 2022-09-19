using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Dialogue;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private List<ActorSpecificDialogue> actorDialogues;

    private List<Dialogue> activeConversation;
    private int index = -1;

    public void SelectConversation(Actor selectedActor)
    {
        for (int i = 0; i < actorDialogues.Count; i++)
        {
            if (actorDialogues[i].actor == selectedActor)
            {
                activeConversation = actorDialogues[i].conversation;
            }
        }
    }
    
    public void NextDialogue()
    {
        if (index + 1 < activeConversation.Count)
        {
            if (index >= 0)
            {
                activeConversation[index].DisableText();
            }
            index++;
            activeConversation[index].EnableText();
        }
        else
        {
            activeConversation[index].DisableText();
            SceneTransitionManager.Instance.LoadSceneTransition(1);
        }
    }



}
