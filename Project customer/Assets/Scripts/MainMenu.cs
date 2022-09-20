using UnityEngine;

/// <summary>
/// Class responsible for the main menu logic and buttons
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Method to close the game (or go back to the editor)
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif

        Application.Quit();
    }

    /// <summary>
    /// Method to start the game
    /// </summary>
    public void StartGame()
    {
        SceneTransitionManager.Instance.LoadSceneTransition(1);
    }
}
