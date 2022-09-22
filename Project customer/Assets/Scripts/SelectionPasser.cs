using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Class responsible for the Selection Passer
/// </summary>
public class SelectionPasser : MonoBehaviour
{
    public static SelectionPasser Instance { get; private set; }
    public List<ActorSelection> selection = new List<ActorSelection>();

    void Awake()
    {
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

    public int AmountCorrect()
    {
        int amount = 0;

        for (int i = 0; i < selection.Count; i++)
        {
            if (selection[i].correct) amount++;
        }
        
        return amount;
    }
    
}
