using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameScript2))]
public class Inspector2 : Editor
{
    public override void OnInspectorGUI()
    {
        GameScript2 gameScript = (GameScript2)target;

        for(int i=0;i<gameScript.listOfInt.Count;i++)
        {
            gameScript.listOfInt[i] = EditorGUILayout.IntSlider("Int Value", gameScript.listOfInt[i], 1, 20);
            if(GUILayout.Button("-"))
            {
                gameScript.Remove(i);
            }
        }

        if(GUILayout.Button("Add"))
        {
            gameScript.AddNew();
        }
    }
}
