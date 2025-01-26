using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 initialPosition; // Store original position

    private void Start()
    {
        initialPosition = transform.position; // Save start position
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddCoin(); // Increase coin count
            gameObject.SetActive(false); // Hide the coin
        }
    }

    public void Respawn()
    {
        gameObject.SetActive(true); // Make the coin visible again
        transform.position = initialPosition; // Reset position (optional)
    }
}
