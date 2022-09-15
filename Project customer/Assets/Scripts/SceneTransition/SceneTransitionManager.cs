using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance { get; private set; }
    [SerializeField] private float sceneTransitionTimePerHalf = 0.5f;
    [SerializeField] private Animator transitionAnimator;
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

    public void LoadSceneTransition(int buildIndex)
    {
        StartCoroutine(LoadSceneAsync(buildIndex));
    }

    private IEnumerator LoadSceneAsync(int buildIndex)
    {
        //Start animation
        transitionAnimator.SetBool("startAnimation",true);
        yield return new WaitForSeconds(sceneTransitionTimePerHalf);
        AsyncOperation async = SceneManager.LoadSceneAsync(buildIndex);
        while (!async.isDone)
        {
            yield return null;
        }
        //start other animation
        transitionAnimator.SetBool("startAnimation",false);
        yield return new WaitForSeconds(sceneTransitionTimePerHalf);
        
        yield break;
    }
    
}
