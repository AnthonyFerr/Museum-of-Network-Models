using UnityEngine;

public class CubeMover : MonoBehaviour
{
    public Transform startPoint;     // The start point of the tube
    public Transform endPoint;       // The end point of the tube
    public float speed = 1.0f;       // Speed of the cube's movement
    private bool isMoving = false;   // To control the movement state

    private void Start()
    {
        // Start the movement immediately (or you could trigger this on an event)
        StartMoving();
    }

    private void Update()
    {
        if (isMoving)
        {
            MoveCube();
        }
    }

    void StartMoving()
    {
        // Start the movement and move to the starting position
        transform.position = startPoint.position;
        isMoving = true;
    }

    void MoveCube()
    {
        // Move the cube smoothly from startPoint to endPoint using Lerp
        float step = speed * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, endPoint.position, step);

        // Check if the cube has reached the end point
        if (Vector3.Distance(transform.position, endPoint.position) < 0.1f)
        {
            // Stop the movement and reset position after a short delay
            isMoving = false;
            Invoke("ResetPosition", 1f);  // Reset the position after 1 second delay
        }
    }

    void ResetPosition()
    {
        // Reset cube's position to the start
        transform.position = startPoint.position;

        // Restart movement after reset
        StartMoving();
    }
}
