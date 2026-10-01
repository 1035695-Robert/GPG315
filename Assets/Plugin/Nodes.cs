using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;

public class Nodes : MonoBehaviour
{
   public Color nodeColour;
   public Transform NextNode;
    public void UpdateNodes() 
    { 
    
    }
    public void UpdateColour()
    {
        Gizmos.color = nodeColour;
        Debug.Log("gizmo");
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }
}
