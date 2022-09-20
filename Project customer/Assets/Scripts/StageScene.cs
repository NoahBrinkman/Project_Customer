using System;
using UnityEngine;

public enum Actor {empty,cop1,cop2,clown1,clown2,mayor1,mayor2}

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
    public int rows = 4;
    public int columns = 4;
    public ActorScene actorScene ;


    public void Initialize()
    {
        if (actorScene.actors == null || actorScene.actors.Length != rows * columns)
        {
            actorScene.SetActorListSize(rows,columns);
        }
    }
    
}

