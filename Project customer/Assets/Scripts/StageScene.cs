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

public class StageScene : MonoBehaviour
{
    [SerializeField] private string prompt = String.Empty;
    [SerializeField] private string outcome = String.Empty;
    public int rows = 4;
    public int columns = 4;
    public ActorScene actorScene = new ActorScene();
    
}

[CustomEditor(typeof(StageScene))]
public class StageSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        StageScene s = (StageScene)target;
        
        if (s.actorScene.actors.Length != s.rows*s.columns)
        {
            s.actorScene.SetActorListSize(s.rows,s.columns);
        }
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
                s.actorScene.actors[index] = (Actor)EditorGUILayout.EnumPopup(s.actorScene.actors[index]);
                index++;
            }
            GUILayout.EndHorizontal();
        }
        //EditorGUILayout.EndHorizontal();
        
        //forloop

    }
}
