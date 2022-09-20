using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private List<ActorSpecificDialogue> actorDialogues;

    private List<Dialogue> activeConversation;
    private int index = -1;

    public UnityEvent OnConversationComplete;
    
    public void SelectConversation(Actor selectedActor, Image image = null, TMP_Text text = null)
    {
        for (int i = 0; i < actorDialogues.Count; i++)
        {
            if (actorDialogues[i].actor == selectedActor)
            {
                activeConversation = actorDialogues[i].conversation;
                for (int j = 0; j < activeConversation.Count; j++)
                {
                    if (activeConversation[j].text == null && text != null)
                    {
                        activeConversation[j].text = text;
                        activeConversation[j].text.text = activeConversation[0].GetText();
                    }
                    if (activeConversation[j].image == null && image != null)
                    {
                        activeConversation[j].image = image;
                    }
                }
                index = 0;
                return;
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
            OnConversationComplete?.Invoke();
        }
    }



}
