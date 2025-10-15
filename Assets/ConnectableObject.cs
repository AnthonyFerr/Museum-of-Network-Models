using UnityEngine;

public class ConnectableObject : MonoBehaviour
{
    public bool isConnected = false;  // Indicates whether this object is currently connected to another
    public WireConnection currentWireConnection;  // The wire that's currently connecting this object

    private void OnMouseDown()
    {
        if (!isConnected)
        {
            // Try to connect to a nearby connectable object
            TryConnect();
        }
        else
        {
            // If already connected, disconnect the wire
            Disconnect();
        }
    }

    private void TryConnect()
    {
        // Raycast to find the object to connect to
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
        {
            ConnectableObject otherObject = hit.collider.GetComponent<ConnectableObject>();
            if (otherObject != null && otherObject != this && !otherObject.isConnected)
            {
                // Establish a wire connection between this object and the hit object
                EstablishConnection(otherObject);
            }
        }
    }

    private void EstablishConnection(ConnectableObject otherObject)
    {
        // Create a wire connection
        GameObject wire = new GameObject("Wire");
        wire.AddComponent<LineRenderer>();
        WireConnection wireConnection = wire.AddComponent<WireConnection>();

        // Set up the wire's connection points and show the line
        wireConnection.DrawWire(transform.position, otherObject.transform.position);

        // Set the wire connections
        currentWireConnection = wireConnection;
        otherObject.currentWireConnection = wireConnection;

        // Mark both objects as connected
        isConnected = true;
        otherObject.isConnected = true;

        wireConnection.connectedObject = otherObject.gameObject;
    }

    private void Disconnect()
    {
        // Disconnect this object and its wire
        if (currentWireConnection != null)
        {
            currentWireConnection.Disconnect();
            currentWireConnection = null;
        }

        isConnected = false;
    }
}
