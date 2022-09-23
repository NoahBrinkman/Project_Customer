using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlaySound("LetterOpen");
        AudioManager.Instance.PlayMusic("Middle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneTransitionManager.Instance.LoadSceneTransition(3,false);
        }
    }
}
