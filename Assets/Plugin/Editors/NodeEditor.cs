using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Nodes))]
public class NodeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.LabelField("Node", EditorStyles.boldLabel);
       
    }
    
}
