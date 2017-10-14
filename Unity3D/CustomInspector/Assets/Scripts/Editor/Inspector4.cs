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
        gameScript.speed = EditorGUILayout.IntSlider("Speed", gameScript.speed, 1, 10);

        if(GUILayout.Button("Save"))
        {
            EditorUtility.SetDirty(gameScript);
            AssetDatabase.SaveAssets();
        }
    }
}
