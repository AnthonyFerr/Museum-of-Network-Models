using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{
    // This can now accept a GameObject directly
    public GameObject connectionPointGameObject;  // Reference to the GameObject

    // Alternatively, you can just use the Transform from the GameObject later.
    public Transform connectionTransform
    {
        get { return connectionPointGameObject != null ? connectionPointGameObject.transform : null; }
    }

    public bool isConnected = false; // Tracks whether it's connected
    public ConnectionPoint connectedTo;  // Reference to the connected connection point
}
