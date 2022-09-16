using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum Actor {empty, person, photographer, clown,cop,childOne, childTwo,childThree, personLocked, photographerLocked, childOneLocked, childTwoLocked,childThreeLocked}

[Serializable]
public class ActorScene
{

    [HideInInspector]public Actor[] actors;
    
    public void SetActorListSize(int rows, int columns)
    {
        if(rows < 0 || columns < 0) return;
        actors = new Actor[rows*columns];
        for (int i = 0; i < rows*columns; i++)
        {
            actors[i] = Actor.empty;
        }
    }
    
}

[CreateAssetMenu(fileName = "StageScene", menuName = "ScriptableObjects/StageScene", order = 1)]
public class StageScene : ScriptableObject
{
    public bool correct = false;
    public string prompt = String.Empty;
    public string outcome = String.Empty;
    public int rows = 4;
    public int columns = 4;
    public ActorScene actorScene = new ActorScene();


    public void Initialize()
    {
        if (actorScene.actors == null || actorScene.actors.Length != rows * columns)
        {
            actorScene.SetActorListSize(rows,columns);
        }
    }
    
}

