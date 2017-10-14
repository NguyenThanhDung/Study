using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameScript3))]
public class Inspector3 : Editor
{
    public override void OnInspectorGUI()
    {
        GameScript3 gameScript = (GameScript3)target;

        for(int i=0;i<gameScript.waves.Count;i++)
        {
            gameScript.waves[i].speed = EditorGUILayout.IntSlider("Speed", gameScript.waves[i].speed, 1, 20);
            if(GUILayout.Button("-"))
            {
                gameScript.waves.RemoveAt(i);
            }
        }

        if (GUILayout.Button("Add"))
        {
            gameScript.waves.Add(new GameScript3.Wave());
        }
    }
}
