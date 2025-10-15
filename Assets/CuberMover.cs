using UnityEngine;

public class CuberMover : MonoBehaviour
{
    public float speed = 2f;  // Speed of movement

    private void Update()
    {
        // Move the object along the X-axis (or any axis you want)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
