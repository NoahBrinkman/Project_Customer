using DefaultNamespace.Dialogue;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class responsible for the EndStageSpots
/// </summary>
public class EndStageSpot : MonoBehaviour
{
    public bool correct = false;
    public Actor occupiedBy = Actor.empty;
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Image image;
    public void Activate()
    {
        image.enabled = true;
        text.enabled = true;
        dialogueManager.SelectConversation(occupiedBy, image, text);

    }

    public void Deactivate()
    {
        text.enabled = false;
        image.enabled = false;
    }
    
}
