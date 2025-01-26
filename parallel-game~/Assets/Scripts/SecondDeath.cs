using UnityEngine;
using System.Collections;

public class SecondhTile : MonoBehaviour
{
    public CanvasGroup fadePanel; // UI fade effect
    public float transitionDuration = 0.5f; // Duration of fade effect
    private Vector2 fixedResetPosition = new Vector2(-3.32f, 48.24f); // Fixed reset position

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Make sure the colliding object is the player
        {
            // Start the fade, reset position, reset coins, and restart counter
            StartCoroutine(HandleDeathTransition(other));
        }
    }

    private IEnumerator HandleDeathTransition(Collider2D player)
    {
        // Pause the game
        Time.timeScale = 0f;

        // Fade to black
        yield return StartCoroutine(FadeToBlack());

        // Reset player position to fixed coordinates
        player.transform.position = fixedResetPosition;

        // Stop player movement
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }

        // Reset the coin counter and respawn coins
        GameManager.instance.ResetCoins();

        // Fade back from black
        yield return StartCoroutine(FadeFromBlack());

        // Resume the game
        Time.timeScale = 1f;
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            fadePanel.alpha = Mathf.Lerp(0f, 1f, elapsedTime / transitionDuration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        fadePanel.alpha = 1f;
    }

    private IEnumerator FadeFromBlack()
    {
        float elapsedTime = 0f;
        while (elapsedTime < transitionDuration)
        {
            fadePanel.alpha = Mathf.Lerp(1f, 0f, elapsedTime / transitionDuration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }
        fadePanel.alpha = 0f;
    }
}
