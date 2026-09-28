using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public float height;
    public float depth;

    public Color nodeColour;
    public Color colliderColour;

    public bool isVisible;
    public bool isClosedLoop;

    public List<GameObject> nodes;
   
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
    

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = colliderColour;
    //    for(int i = 0; i < nodes.Count; i++)
    //    {
    //        Gizmos.DrawLine(nodes[i].transform.position, nodes[i + 1].transform.position);
    //    }
    //}
}
