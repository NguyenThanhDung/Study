using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameScript4))]
public class Inspector4 : Editor
{
    public override void OnInspectorGUI()
    {
        GameScript4 gameScript = (GameScript4)target;

        for (int i = 0; i < gameScript.waves.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            gameScript.waves[i].speed = EditorGUILayout.IntSlider("Speed", gameScript.waves[i].speed, 1, 20);
            if (GUILayout.Button("-"))
            {
                gameScript.waves.RemoveAt(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add"))
        {
            gameScript.waves.Add(new GameScript4.Wave());
        }

        if (GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(gameScript);
            AssetDatabase.SaveAssets();
        }
    }
}
