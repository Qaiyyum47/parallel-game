using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f; // Horizontal speed of the bubble
    public float floatSpeed = 10f * 10f; // Vertical float speed of the bubble

    private Rigidbody2D rb;
    private bool isMirrored = false; // Track whether the bubble is mirrored

    void Start()
    {
        // Get the Rigidbody2D component for physics interaction
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for horizontal movement (arrow keys or WASD by default)
        float moveInput = Input.GetAxis("Horizontal");

        // If the bubble is mirrored, reverse the movement direction
        if (isMirrored)
        {
            moveInput = -moveInput; // Reverse the horizontal input when mirrored
        }

        // Apply horizontal movement to the bubble
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, floatSpeed); // Keep the vertical speed unaffected

        if (Input.GetKeyDown(KeyCode.Space))  // Mirror position and movement on spacebar press
        {
            // Flip the position on the X-axis
            rb.position = new Vector2(-rb.position.x, rb.position.y);

            // Toggle the mirroring state
            isMirrored = !isMirrored;
        }
    }
}
