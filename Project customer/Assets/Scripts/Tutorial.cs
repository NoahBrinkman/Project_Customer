using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    [SerializeField] private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        dialogueManager.SelectConversation(Actor.manager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToNextScene()
    {
        SceneTransitionManager.Instance.LoadSceneTransition(4);
    }
}
