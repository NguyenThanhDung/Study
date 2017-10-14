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
        EditorGUILayout.IntSlider(serializedObject.FindProperty("speed"), 1, 20, "Speed");
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Save"))
        {
            AssetDatabase.SaveAssets();
        }
    }
}
