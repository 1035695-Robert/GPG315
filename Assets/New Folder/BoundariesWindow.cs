using UnityEngine;
using UnityEditor;
using System.ComponentModel;
using UnityEngine.UIElements;

public class BoundariesWindow : EditorWindow
{
    public float height;
    public float depth;

    public int nodeCount;

    public string tabs;

    public Color nodeColour;
    public Color ColliderColour;

    public bool isVisible;
    public bool isClosedLoop;

    public string currentPanel;
    [MenuItem("Window/Boundaries")]
    public static void ShowWindow()
    {
        GetWindow<BoundariesWindow>("Boundaries");
    }

    //private void OnEnable()
    //{
    //     TabView tabview = new TabView();
    //    Tab tab1 = new Tab("Nodes");
    //    tab1.Add(new Label("work with nodes"));

    //    Tab tab2 = new Tab("colour");
    //    tab2.Add(new Button(() => Debug.Log("Colour tools")) { text = "run colour"});

    //    tabview.Add(tab1);
    //    tabview.Add(tab2);

    //    rootVisualElement.Add(tabview);
    //}
    private void OnGUI()
    {
        //tabs = GUILayout.Toolbar(tabs, new string[] { "nodes", "colour" });
        //switch()
        GUILayout.Label("Nodes", EditorStyles.boldLabel);

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Add Node"))
        {
            //adds a Node
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


        nodeCount = EditorGUILayout.IntField("Base Count", nodeCount);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Dimention", EditorStyles.boldLabel);
        height = EditorGUILayout.FloatField("Height", height);
        depth = EditorGUILayout.FloatField("Wall Depth", depth);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Colour", EditorStyles.boldLabel);
        nodeColour = EditorGUILayout.ColorField("Node Colour", nodeColour);
        ColliderColour = EditorGUILayout.ColorField("Collider Colour", ColliderColour);

        if (GUILayout.Button("Confirm Colour"))
        {
            //
        }
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Toggles", EditorStyles.boldLabel);

        isVisible = EditorGUILayout.Toggle("Visiblility", isVisible);
        isClosedLoop = EditorGUILayout.Toggle("Closed Loop", isClosedLoop);

        if (GUILayout.Button("Close"))
        {
            // closes Window panel
            this.Close();
        }

    }
    
}
