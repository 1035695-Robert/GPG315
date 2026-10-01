using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class BoundaryPoints
{
    [HideInInspector] public string name;
    public Vector3 points;
    public GameObject node;
    
    
}
public class Boundary : MonoBehaviour
{
    public float height;
    public float depth;

    public Color nodeColour =  Color.red;
    public Color lineColour = Color.white;
    public Color colliderColour  = Color.blue;
    
 
    public bool isVisible;
    public bool isClosedLoop;

    public List<BoundaryPoints> boundaryPoints = new();
    public List<Vector3> points = new();
    public float progress;
    public int waypoint;
    

    public void UpdateDimension()
    {
        Debug.Log(height);
    }

    public void UpdateColour()
    {Debug.Log(nodeColour);
        foreach(Transform node in transform)
        {
            Debug.Log(node.name);
            Nodes nodeScript = node.GetComponent<Nodes>();
            if (nodeScript != null)
                nodeScript.UpdateColour();
        }
    }

    public void Reset()
    {
       
    }
    public void Confirm()
    {
        //deletes all node scripts

    }

    public void AddPoints(string namePoint, Vector3 point )
    {
        BoundaryPoints newPoint = new();
        newPoint.name = namePoint;
        newPoint.points = point;
        boundaryPoints.Add(newPoint);
    }

    
}
