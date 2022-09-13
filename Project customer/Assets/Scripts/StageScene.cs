using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum Actor {empty, person, photographer, childOne, childTwo,childThree, personLocked, photographerLocked, childOneLocked, childTwoLocked,childThreeLocked}

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

[CustomEditor(typeof(StageScene))]
public class StageSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(target == null) return;
        StageScene s = (StageScene)target;
        if(s == null) return;
        s.Initialize();

        base.OnInspectorGUI();
        
       
        if(s == null || target == null) return;

        EditorGUILayout.Space();
       
       
        int index = 0;
        for (int i = 0; i < s.rows; i++)
        {
            GUILayout.BeginHorizontal();
            for (int j = 0; j < s.columns; j++)
            {
                if(index >= s.actorScene.actors.Length || index < 0) return;
                s.actorScene.actors[index] = (Actor)EditorGUILayout.EnumPopup(s.actorScene.actors[index], GUILayout.Width(60), GUILayout.MaxWidth(80));
                index++;
            }
            GUILayout.EndHorizontal();
        }
        //EditorGUILayout.EndHorizontal();
        
        //forloop

    }
}
