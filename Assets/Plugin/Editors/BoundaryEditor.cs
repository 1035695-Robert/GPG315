using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

[CustomEditor(typeof(Boundary))]
public class BoundaryEditor : Editor
{
    private bool showColour;
    public override void OnInspectorGUI()
    {
        Boundary boundary = (Boundary)target;

        EditorGUILayout.LabelField("Boundary", EditorStyles.boldLabel);


        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Dimension", EditorStyles.boldLabel);

        EditorGUI.BeginChangeCheck();
        boundary.height = EditorGUILayout.DelayedFloatField("Height", boundary.height);
        boundary.depth = EditorGUILayout.DelayedFloatField("Wall Depth", boundary.depth);
        if (EditorGUI.EndChangeCheck())
        {
            boundary.UpdateDimension();
        }


        EditorGUILayout.Space();


        //EditorGUILayout.LabelField("Colour", EditorStyles.boldLabel);
        EditorGUI.BeginChangeCheck();
        showColour = EditorGUILayout.Foldout(showColour, "Colours", true, EditorStyles.foldout);
        if (showColour)
        {
            EditorGUI.indentLevel++;

            boundary.nodeColour = EditorGUILayout.ColorField("Node Colour", boundary.nodeColour);
            boundary.lineColour = EditorGUILayout.ColorField("Line Colour", boundary.lineColour);
            boundary.colliderColour = EditorGUILayout.ColorField("Collider Colour", boundary.colliderColour);
            EditorGUI.indentLevel--;
        }

        if (EditorGUI.EndChangeCheck())
        {
            boundary.UpdateColour();
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Toggles", EditorStyles.boldLabel);

        boundary.isVisible = EditorGUILayout.Toggle("Visibility", boundary.isVisible);
        boundary.isClosedLoop = EditorGUILayout.Toggle("Closed Loop", boundary.isClosedLoop);

        EditorGUILayout.Space();

        // EditorGUILayout.PropertyField(serializedObject.FindProperty("points"), true);
        // serializedObject.ApplyModifiedProperties();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("boundaryPoints"), true);
        serializedObject.ApplyModifiedProperties();

        if (GUILayout.Button("Reset"))
        {
            //Resets the boundary nodes
        }


        if (GUILayout.Button("Confirm"))
        {
            boundary.UpdateDimension();
        }
    }

    public void OnSceneGUI()
    {
        Boundary boundary = (Boundary)target;
        
        
        Vector3 boundaryPosition = boundary.transform.position;
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        
        
        for (int i = 0; i < boundary.boundaryPoints.Count; i++)
        {
            Handles.Label( (boundary.boundaryPoints[i].points + boundaryPosition), $"{i+1}");
            Handles.color = boundary.nodeColour;
            Handles.CubeHandleCap(0, boundary.boundaryPoints[i].points + boundaryPosition,
                Quaternion.identity,
                0.05f,
                EventType.Repaint);
            
            EditorGUI.BeginChangeCheck();
            
            Vector3 newTargetPoint = Handles.PositionHandle(boundary.boundaryPoints[i].points, Quaternion.identity);
            if (EditorGUI.EndChangeCheck())
            { Undo.RecordObject(boundary, "Move Point");
                boundary.boundaryPoints[i].points = newTargetPoint;
            }
            
            
            Handles.color = boundary.lineColour;
            int next = (i + 1) % boundary.boundaryPoints.Count;
            Handles.DrawLine(boundary.boundaryPoints[i].points + boundaryPosition,
                boundary.boundaryPoints[next].points + boundaryPosition,
                1f);
            if (boundary.height > 0)
            {
                Handles.DrawLine(boundary.boundaryPoints[i].points + boundaryPosition + (Vector3.up * boundary.height),
                    boundary.boundaryPoints[next].points + boundaryPosition + (Vector3.up * boundary.height),
                    1f);
                Handles.DrawLine(boundary.boundaryPoints[i].points + boundaryPosition,
                    boundary.boundaryPoints[i].points + boundaryPosition + (Vector3.up * boundary.height),
                    1f);
            }
            Handles.color = boundary.colliderColour;
            Handles.SphereHandleCap(0, 
                ((boundary.boundaryPoints[i].points + boundaryPosition) + 
                 (boundary.boundaryPoints[next].points + boundaryPosition))/2 + Vector3.up * boundary.height/2, 
                Quaternion.identity, 0.05f, EventType.Repaint);
            
        }
    }
}