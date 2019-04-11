using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameScript1))]
public class Inspector1 : Editor
{
    public override void OnInspectorGUI()
    {
        GameScript1 gsTarget = (GameScript1)target;
        gsTarget.anInt = EditorGUILayout.IntSlider("AnInt", gsTarget.anInt, 10, 20);
    }
}
