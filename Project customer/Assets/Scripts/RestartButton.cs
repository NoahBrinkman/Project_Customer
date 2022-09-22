using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void OnClick()
    {
        Destroy(AudioManager.Instance.gameObject);
        Destroy(SceneTransitionManager.Instance.gameObject);
        Destroy(GameObject.FindWithTag("Passer"));
        SceneManager.LoadScene(0);
    }
}
