using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameScript4))]
public class Inspector4 : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        SerializedProperty waves = serializedObject.FindProperty("waves");

        for (int i = 0; i < waves.arraySize; i++)
        {
            EditorGUILayout.BeginHorizontal();
            SerializedProperty wave = waves.GetArrayElementAtIndex(i);
            SerializedProperty speed = wave.FindPropertyRelative("speed");
            EditorGUILayout.IntSlider(speed, 1, 20, "Speed");
            if (GUILayout.Button("-"))
            {
                waves.DeleteArrayElementAtIndex(i);
            }
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add"))
        {
            waves.InsertArrayElementAtIndex(waves.arraySize);
        }

        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Save"))
        {
            AssetDatabase.SaveAssets();
        }
    }
}
