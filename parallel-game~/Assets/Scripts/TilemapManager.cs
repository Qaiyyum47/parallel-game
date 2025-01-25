using UnityEngine;

public class TilemapToggle : MonoBehaviour
{
    private GameObject tilemap1; // Reference to the first tilemap GameObject
    private GameObject tilemap2; // Reference to the second tilemap GameObject

    void Start()
    {
        // Get the Tilemap GameObjects from the Grid's children
        tilemap1 = transform.Find("WorldA").gameObject;
        tilemap2 = transform.Find("WorldB").gameObject;

        // Initially disable tilemap2 GameObject, ensure tilemap1 is active
        tilemap1.SetActive(true);
        tilemap2.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Toggle on spacebar press
        {
            // Toggle the active state of the entire tilemap GameObjects
            bool tilemap1Active = tilemap1.activeSelf; // Check if tilemap1 is active
            tilemap1.SetActive(!tilemap1Active); // Set tilemap1 to the opposite state
            tilemap2.SetActive(tilemap1Active); // Set tilemap2 to the state of tilemap1 before
        }
    }
}
