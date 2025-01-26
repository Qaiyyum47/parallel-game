using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TilemapToggle : MonoBehaviour
{
    private GameObject tilemap1;
    private GameObject tilemap2;

    public GameObject playerBubble; // Your single bubble GameObject
    public CanvasGroup fadePanel; // Canvas for the fade effect
    private SpriteRenderer playerBubbleRenderer;

    public Color worldAColor = Color.blue; // Color for World A
    public Color worldBColor = Color.green; // Color for World B
    private float fadeDuration = 0.5f; // Duration of fade effect

    void Start()
    {
        tilemap1 = transform.Find("WorldA").gameObject;
        tilemap2 = transform.Find("WorldB").gameObject;
        playerBubbleRenderer = playerBubble.GetComponent<SpriteRenderer>();

        tilemap1.SetActive(true);
        tilemap2.SetActive(false);

        fadePanel.alpha = 0; // Ensure screen starts visible
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Toggle on spacebar press
        {
            StartCoroutine(FadeAndSwitch());
        }
    }

    IEnumerator FadeAndSwitch()
    {
        // Pause game time
        Time.timeScale = 0f;

        yield return StartCoroutine(FadeToBlack()); // Fade to black

        // Toggle active tilemap
        bool tilemap1Active = tilemap1.activeSelf;
        tilemap1.SetActive(!tilemap1Active);
        tilemap2.SetActive(tilemap1Active);

        // Change the bubble color based on the active world
        if (tilemap1Active) // If we were in World A, now in World B
        {
            StartCoroutine(ChangeBubbleColor(worldBColor));
        }
        else // If we were in World B, now in World A
        {
            StartCoroutine(ChangeBubbleColor(worldAColor));
        }

        yield return StartCoroutine(FadeFromBlack()); // Fade back in

        // Resume game time
        Time.timeScale = 1f;
    }

    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            elapsedTime += Time.unscaledDeltaTime; // Use unscaledDeltaTime to ignore Time.timeScale
            yield return null;
        }
        fadePanel.alpha = 1f; // Ensure fully black screen
    }

    IEnumerator FadeFromBlack()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            fadePanel.alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            elapsedTime += Time.unscaledDeltaTime; // Use unscaledDeltaTime to ignore Time.timeScale
            yield return null;
        }
        fadePanel.alpha = 0f; // Ensure fully visible screen
    }

    IEnumerator ChangeBubbleColor(Color targetColor)
    {
        Color currentColor = playerBubbleRenderer.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            playerBubbleRenderer.color = Color.Lerp(currentColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.unscaledDeltaTime; // Use unscaledDeltaTime for smooth transition
            yield return null;
        }
        playerBubbleRenderer.color = targetColor; // Set the final color
    }
}
