using UnityEngine;
using UnityEditor;


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
            CreateBaseBoundary();
        }

        EditorGUI.BeginDisabledGroup(!hasCorrectTag);
        GUILayout.Label("Nodes", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Node"))
        {
            //adds a Node
            AddNodes(selectedObject);
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


    private void CreateBaseBoundary()
    {
        GameObject newBoundary = new GameObject(_objectName);
        newBoundary.tag = "Boundary";
        boundary = newBoundary.AddComponent<Boundary>();

        Undo.RegisterCreatedObjectUndo(newBoundary, "Created Boundary" + _objectName);
        for (int i = 0; i < baseNodeCount; i++)
        {
            float angle = i * Mathf.PI *2 / baseNodeCount;
            float x = Mathf.Cos(angle) * baseRadius;
            float z = Mathf.Sin(angle) * baseRadius;
            Vector3 spawnPoint = newBoundary.transform.position + new Vector3(x, 0, z);
            
            AddNode($"node {i}", spawnPoint);
            // GameObject newNode = AddNodes(newBoundary);
            // newNode.transform.position = new Vector3(0, 0, baseRadius * i);
            // Nodes settings = newNode.AddComponent<Nodes>();
            // //boundary.nodes.Add(newNode);
        }

        Selection.activeGameObject = newBoundary;
        //Debug.Log(baseNodeCount);
        //Debug.Log(boundary.nodes.Count);
    }

    private GameObject AddNodes(GameObject newBoundary)
    {
        GameObject newNode = new GameObject("Node");
        newNode.transform.parent = newBoundary.transform;
        //boundary.AddPoints();
        return newNode;
    }


    private void AddNode(string name, Vector3 nodePoint)
    {
        boundary.AddPoints(name, nodePoint);
    }

    private void RemoveNodes()
    {
    }
}