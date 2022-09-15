using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR


[CustomEditor(typeof(StageScene))]
public class StageSceneEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(target == null) return;
        StageScene s = (StageScene)target;
        if(s == null) return;
        if(s.actorScene.actors.Length != s.columns*s.rows)
            s.Initialize();

        base.OnInspectorGUI();
        EditorUtility.SetDirty(s);
       
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
#endif