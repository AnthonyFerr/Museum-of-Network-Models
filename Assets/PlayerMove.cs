using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f; // Movement speed
    public float mouseSensitivity = 2f; // Mouse sensitivity for looking around
    public Transform playerCamera; // Reference to the Camera
    private float xRotation = 0f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Hide the cursor and lock it to the center
        Cursor.visible = false;
    }

    void Update()
    {
        // Look around with the mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limit up and down rotation

        playerCamera.Rotate(Vector3.left * mouseY); // Rotate camera vertically
        transform.Rotate(Vector3.up * mouseX); // Rotate the player horizontally

        // Move the player (WASD controls)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        controller.Move(move * speed * Time.deltaTime);
    }
}
