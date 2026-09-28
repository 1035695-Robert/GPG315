using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Boundary))]
public class BoundaryEditor : Editor
{
   

   


  
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


        EditorGUILayout.LabelField("Colour", EditorStyles.boldLabel);
        EditorGUI.BeginChangeCheck();
        boundary.nodeColour = EditorGUILayout.ColorField("Node Colour", boundary.nodeColour);

     
        boundary.colliderColour = EditorGUILayout.ColorField("Collider Colour", boundary.colliderColour);
        if(EditorGUI.EndChangeCheck())
        {
            boundary.UpdateColour();
        }
        
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Toggles", EditorStyles.boldLabel);

        boundary.isVisible = EditorGUILayout.Toggle("Visibility", boundary.isVisible);
        boundary.isClosedLoop = EditorGUILayout.Toggle("Closed Loop", boundary.isClosedLoop);

        EditorGUILayout.Space();

        if (GUILayout.Button("Reset"))
        {
            //Resets the boundary nodes
        }

        if (GUILayout.Button("Confirm"))
        {
            boundary.UpdateDimension();
        }
    }

}
