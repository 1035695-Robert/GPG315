using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;


public class BoundariesWindow : EditorWindow
{
    public float height;
    public float depth;

    public int baseNodeCount;
    public float baseRadius;

    public string tabs;

    public Color nodeColour;
    public Color colliderColour;

    
    public bool isVisible;
    public bool isClosedLoop;

    private string _objectName = "Boundary";
    
    [MenuItem("Window/Boundaries")]
    public static void ShowWindow()
    {
        GetWindow<BoundariesWindow>("Boundaries");
    }

    private void OnSelectionChange()
    {
        Repaint();
    }

    private void OnGUI()
    {
        GameObject selectedObject = Selection.activeGameObject;

        string targetTag = "Boundary";
        bool hasCorrectTag = selectedObject && selectedObject.CompareTag(targetTag);

        baseNodeCount = EditorGUILayout.IntField("Corner Count", baseNodeCount);
        baseRadius = EditorGUILayout.FloatField("center", baseRadius);
        if (GUILayout.Button("New Boundary"))
        {
            CreateBoundary();
        }
       
        EditorGUI.BeginDisabledGroup(!hasCorrectTag);
        GUILayout.Label("Nodes", EditorStyles.boldLabel);



        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Node"))
        {
            //adds a Node
            AddNodes();
        }
        if (GUILayout.Button("Remove Node"))
        {
            //remove selected node OR Last node
        }
        GUILayout.EndHorizontal();



        if (GUILayout.Button("Reset"))
        {
            //Resets the boundary nodes
        }

        if (GUILayout.Button("Confirm"))
        {
            //Confirms the Boundaries
        }



        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Dimension", EditorStyles.boldLabel);
        height = EditorGUILayout.FloatField("Height", height);
        depth = EditorGUILayout.FloatField("Wall Depth", depth);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Colour", EditorStyles.boldLabel);
        nodeColour = EditorGUILayout.ColorField("Node Colour", nodeColour);
        colliderColour = EditorGUILayout.ColorField("Collider Colour", colliderColour);

        if (GUILayout.Button("Confirm Colour"))
        {
            //
        }
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Toggles", EditorStyles.boldLabel);

        isVisible = EditorGUILayout.Toggle("Visibility", isVisible);
        isClosedLoop = EditorGUILayout.Toggle("Closed Loop", isClosedLoop);
        EditorGUI.EndDisabledGroup();


        if (GUILayout.Button("Close"))
        {
            // closes Window panel
            this.Close();
        }
    }

    
    private void CreateBoundary()
    {
        GameObject newBoundary = new GameObject(_objectName);
        newBoundary.tag = "Boundary";
        Undo.RegisterCreatedObjectUndo(newBoundary, "Created Boundary" + _objectName);
        for (int i = 0; i < baseNodeCount; i++)
        {
            GameObject newNode = new GameObject("Node");
            newNode.transform.parent = newBoundary.transform;
            newNode.transform.position = new Vector3(0, 0, baseRadius * i);
            
            //place them in 
            
        }
        Selection.activeGameObject = newBoundary;
        Debug.Log(baseNodeCount);
    }

    private void AddNodes()
    {
        GameObject newNode = new GameObject("Node");
        newNode.transform.parent = Selection.activeGameObject.transform;

    }
 }
