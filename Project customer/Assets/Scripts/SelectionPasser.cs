using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class responsible for the Selection Passer
/// </summary>
public class SelectionPasser : MonoBehaviour
{
    public List<ActorSelection> selection = new List<ActorSelection>();
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
