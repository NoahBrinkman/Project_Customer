using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }
    [SerializeField] private float sceneTransitionTimePerHalf = 0.5f;
    [SerializeField] private Animator transitionAnimator;
    private bool intransit = false;

    private bool tutorialShown = false;
    
    private void Awake() 
    { 
        // If there is an instance, and it's not me, delete myself.
    
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

    public void HandleTutorial()
    {
        GameObject tutorialImage = GameObject.FindWithTag("Tutorial");
        if (tutorialImage != null)
        {
            if (tutorialShown)
            {
                tutorialImage.SetActive(false);
            }
            else
            {
                tutorialShown = true;
            }
        }
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                 UnityEditor.EditorApplication.isPlaying = false;
            #endif

            Application.Quit();
        }
    }

    public void LoadSceneTransition(int buildIndex, bool useStandardTransition = true, float waitBeforeFullTransition = 0)
    {
        if(intransit) return;
        intransit = true;
        StartCoroutine(LoadSceneAsync(buildIndex, useStandardTransition, waitBeforeFullTransition));
    }

    private IEnumerator LoadSceneAsync(int buildIndex, bool useStandardTransition, float waitBeforeFullTransition = 0)
    {
        //Start animation
        if (useStandardTransition)
        {
            transitionAnimator.SetBool("startAnimation",true);
            AudioManager.Instance.PlaySound("Curtain");
        }
           
        else
            transitionAnimator.SetBool("startAnimationVariant",true);
        yield return new WaitForSeconds(sceneTransitionTimePerHalf);
        yield return new WaitForSeconds(waitBeforeFullTransition);
        AsyncOperation async = SceneManager.LoadSceneAsync(buildIndex);
        while (!async.isDone)
        {
            yield return null;
        }
        //start other animation
        if (useStandardTransition)
        {
            transitionAnimator.SetBool("startAnimation",false);
            AudioManager.Instance.PlaySound("Curtain");
        }
        else
            transitionAnimator.SetBool("startAnimationVariant",false);
        yield return new WaitForSeconds(sceneTransitionTimePerHalf);
        intransit = false;
        yield break;
    }
    
}
