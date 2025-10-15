using UnityEngine;

public class WireConnection : MonoBehaviour
{
    public GameObject connectedObject;  // The object this wire is connected to
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Collider collider = gameObject.AddComponent<BoxCollider>();  // Adds a BoxCollider to the object
        collider.isTrigger = true;  // Set to true to allow triggering without physical collisions
    }

    // Draw the line between the two objects (Laptop and Server)
    public void DrawWire(Vector3 startPosition, Vector3 endPosition)
    {
        lineRenderer.SetPosition(0, startPosition);
        lineRenderer.SetPosition(1, endPosition);
    }

    // Disconnect the wire
    public void Disconnect()
    {
        connectedObject = null;
        lineRenderer.enabled = false;  // Disable the line when disconnected
    }
}
