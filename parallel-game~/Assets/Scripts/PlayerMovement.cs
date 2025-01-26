using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Horizontal speed of the bubble
    public float floatSpeed = 10f; // Vertical float speed of the bubble

    private Rigidbody2D rb;

    void Start()
    {
        // Get the Rigidbody2D component for physics interaction
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for horizontal movement (arrow keys or WASD by default)
        float moveInput = Input.GetAxis("Horizontal");

        // Apply horizontal and vertical movement to the bubble
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, floatSpeed); // Vertical speed stays constant
    }
}
