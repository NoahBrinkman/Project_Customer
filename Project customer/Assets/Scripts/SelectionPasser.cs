using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionPasser : MonoBehaviour
{
    public List<ActorSelection> selection = new List<ActorSelection>();
    void Start()
    {
        DontDestroyOnLoad(this);
    }


}
