using UnityEngine;

/// <summary>
/// Class responsible for Actor connected variables
/// </summary>
public class GrabbableActor : MonoBehaviour
{
    [HideInInspector] public Vector3 startPosition;
    public Actor actor = Actor.empty;

    [TextArea] public string endSceneDialogue;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
}
