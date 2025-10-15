using UnityEngine;

public class WireManager : MonoBehaviour
{
    public GameObject wirePrefab;  // Reference to the wire prefab
    private GameObject currentWire; // The wire being drawn
    private ConnectionPoint firstConnectionPoint; // First selected connection point
    private ConnectionPoint secondConnectionPoint; // Second selected connection point

    private bool isWireBeingDrawn = false; // Flag to track whether a wire is being drawn

    void Update()
    {
        // Detect mouse click for creating connections
        if (Input.GetMouseButtonDown(0)) // Left click to connect/disconnect
        {
            TryCreateWire();
        }
    }

    void TryCreateWire()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if we hit a valid connection point (component of a computer/server)
            ConnectionPoint connectionPoint = hit.collider.GetComponent<ConnectionPoint>();

            if (connectionPoint != null)
            {
                if (!isWireBeingDrawn)
                {
                    firstConnectionPoint = connectionPoint;
                    isWireBeingDrawn = true;
                }
                else
                {
                    secondConnectionPoint = connectionPoint;

                    // Create a wire between the two connection points
                    CreateWire(firstConnectionPoint.connectionPointGameObject, secondConnectionPoint.connectionPointGameObject);

                    // Optionally, update the connection state
                    firstConnectionPoint.isConnected = true;
                    secondConnectionPoint.isConnected = true;

                    // Optionally, track the connected points (for disconnection logic, etc.)
                    firstConnectionPoint.connectedTo = secondConnectionPoint;
                    secondConnectionPoint.connectedTo = firstConnectionPoint;

                    // Reset for the next connection
                    firstConnectionPoint = null;
                    secondConnectionPoint = null;
                    isWireBeingDrawn = false;
                }
            }
        }
    }

    void CreateWire(GameObject startPointGameObject, GameObject endPointGameObject)
    {
        // Instantiate a new wire prefab
        currentWire = Instantiate(wirePrefab, Vector3.zero, Quaternion.identity);
        LineRenderer lineRenderer = currentWire.GetComponent<LineRenderer>();

        // Access the position of the GameObject's Transform for the wire start and end points
        lineRenderer.SetPosition(0, startPointGameObject.transform.position); // Start position
        lineRenderer.SetPosition(1, endPointGameObject.transform.position);   // End position
    }
}
