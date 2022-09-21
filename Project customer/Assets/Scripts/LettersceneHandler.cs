using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneTransitionManager.Instance.LoadSceneTransition(2,false);
        }
    }
}
