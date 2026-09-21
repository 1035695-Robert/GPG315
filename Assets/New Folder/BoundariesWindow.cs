using UnityEngine;
using UnityEditor;

public class BoundariesWindow : EditorWindow
{
    public float height;
    public float depth;

    public Color nodeColour;
    public Color ColliderColour;

    public bool isVisible;
    public bool isClosedLoop;
    
    [MenuItem("Window/Boundaries")]
    public static void ShowWindow()
    {
        GetWindow<BoundariesWindow>("Boundaries");
    }

    private void OnGUI()
    {
        GUILayout.Label("Boundaries", EditorStyles.boldLabel);

        if (GUILayout.Button("Reset"))
        {
            //Resets the boundary nodes
        }

        if (GUILayout.Button("Confirm"))
        {
            //Confirms the Boundaries
        }

        if(GUILayout.Button("Add Node"))
        {
            //adds a Node
        }
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Dimention", EditorStyles.boldLabel);
        height = EditorGUILayout.FloatField("Height", height);
        depth = EditorGUILayout.FloatField("Wall Depth", depth);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Colour", EditorStyles.boldLabel);
        nodeColour = EditorGUILayout.ColorField("Node Colour", nodeColour);
        ColliderColour = EditorGUILayout.ColorField("Collider Colour", ColliderColour);

        if (GUILayout.Button("Confirm Colour"))
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Toggles", EditorStyles.boldLabel);

        isVisible = EditorGUILayout.Toggle("Visiblility", isVisible);
        isClosedLoop = EditorGUILayout.Toggle("Closed Loop", isClosedLoop);


        
        if (GUILayout.Button("Close"))
        {
            this.Close();
        }

    }
}
