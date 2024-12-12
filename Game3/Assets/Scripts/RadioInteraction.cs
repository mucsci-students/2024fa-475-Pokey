using UnityEngine;
using UnityEngine.SceneManagement;

public class RadioInteraction : MonoBehaviour
{
    public string inspectSceneName = "InspectSceneRadio"; // Name of the scene to load

    // This method is triggered when the player interacts with the radio
    public void InspectRadio()
    {
        // Load the inspect radio scene additively (so the original scene stays loaded)
        SceneManager.LoadScene(inspectSceneName, LoadSceneMode.Additive);

        // Optionally disable player movement or other actions if needed
        FPSController movement = GetComponent<FPSController>();
        movement.enabled = false;

        // You can also handle enabling/disabling UI or objects as needed
        PlayerInteract interact = GetComponent<PlayerInteract>();
        interact.inScene = 1; // Indicate that we are now in the inspect scene
    }
}