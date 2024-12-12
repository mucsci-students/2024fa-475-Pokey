using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaneStepCheck : MonoBehaviour
{
    [SerializeField] private string endSceneName = "EndScene"; // Name of the end scene
    [SerializeField] private GameObject player; // Reference to the player object

    private Collider planeCollider;

    void Start()
    {
        // Get the plane's collider
        planeCollider = GetComponent<Collider>();

        if (planeCollider == null)
        {
            Debug.LogError("No Collider found on the plane! Add a Collider component.");
        }
    }

    void Update()
    {
        // Check if the player is within the plane's bounds
        if (planeCollider.bounds.Contains(player.transform.position))
        {
            Debug.Log("Player stepped on the plane!");
            SceneManager.LoadScene(endSceneName);
        }
    }
}