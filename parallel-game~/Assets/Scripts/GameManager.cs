using UnityEngine;
using TMPro; // For TextMeshPro UI

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton
    public int coinCount = 0; // Coin counter
    public TextMeshProUGUI coinText; // UI text display

    private Coin[] allCoins; // Store all coin objects

    private void Awake()
    {
        // Singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Find all coins in the scene
        allCoins = FindObjectsOfType<Coin>();
    }

    public void AddCoin()
    {
        coinCount++;
        UpdateCoinUI();
    }

    public void ResetCoins()
    {
        coinCount = 0;
        UpdateCoinUI();

        // Respawn all coins
        foreach (Coin coin in allCoins)
        {
            coin.Respawn();
        }
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount;
        }
    }
}
