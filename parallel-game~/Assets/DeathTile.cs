using UnityEngine;

public class DeathTile : MonoBehaviour
{
    public Vector2 startPosition; // The starting position to reset the bubble when it touches the tile

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Make sure the colliding object is the player
        {
            // Reset player's position to start position
            other.transform.position = startPosition;
            // Optionally, you can also reset any other properties like velocity
            other.GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;  // Stop the bubble's movement
        }
    }
}
