using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayMusic("Opening");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneTransitionManager.Instance.LoadSceneTransition(2, false);
        }
    }
}
