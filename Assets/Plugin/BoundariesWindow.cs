using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;


public class BoundariesWindow : EditorWindow
{
  
    public int baseNodeCount;
    public float baseRadius;

    public string tabs;

    private Boundary boundary;
   

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
        if (hasCorrectTag)
        {
            boundary = selectedObject.GetComponent<Boundary>();
        }
        else
        {
            boundary = null;
        } 
           
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
        Boundary nodeControls = newBoundary.AddComponent<Boundary>();

        Undo.RegisterCreatedObjectUndo(newBoundary, "Created Boundary" + _objectName);
        for (int i = 0; i < baseNodeCount; i++)
        {
            GameObject newNode = new GameObject("Node");
            newNode.transform.parent = newBoundary.transform;
            newNode.transform.position = new Vector3(0, 0, baseRadius * i);
            Nodes settings = newNode.AddComponent<Nodes>();
            boundary.nodes.Add(newNode);
        }
        Selection.activeGameObject = newBoundary;
        //Debug.Log(baseNodeCount);
        Debug.Log(boundary.nodes.Count);
    }

    private void AddNodes()
    {
        GameObject newNode = new GameObject("Node");
        newNode.transform.parent = Selection.activeGameObject.transform;
       if(boundary != null)
        {
            boundary.nodes.Add(newNode);
           foreach(GameObject go in boundary.nodes)
            {
                Debug.Log(go.name);
            }
        }
    }

    private void RemoveNodes() 
    { 
       
    }
  

}
