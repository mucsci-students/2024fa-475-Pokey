using UnityEngine;
using UnityEngine.SceneManagement;

public class PadlockInteraction : MonoBehaviour
{
    public GameObject player;
    public bool interacting;
    public GameObject helpText;
    //public string inspectSceneName = "InspectScenePadlock"; // Name of the scene to load

    // This method is triggered when the player interacts with the radio
    // public void InspectPadlock()
    // {
    //     // Load the inspect radio scene additively (so the original scene stays loaded)
    //     SceneManager.LoadScene(inspectSceneName, LoadSceneMode.Additive);

    //     // Optionally disable player movement or other actions if needed
    //     FPSController movement = GetComponent<FPSController>();
    //     movement.enabled = false;

    //     // You can also handle enabling/disabling UI or objects as needed
    //     PlayerInteract interact = GetComponent<PlayerInteract>();
    //     interact.inScene = 1; // Indicate that we are now in the inspect scene
    // }
    // public void Update() {
    // if (Input.GetKeyDown(KeyCode.Escape))
    //     {
    //         SceneManager.UnloadSceneAsync("InspectScenePadlock");
    //         FPSController movement = GetComponent<FPSController>();
    //         movement.enabled = true;
    //         PlayerInteract interact = GetComponent<PlayerInteract>();
    //         interact.inScene = 0;
    //     }
    // }
    public void interact() {
        if (!interacting) {
            helpText.SetActive(true);
         player.GetComponent<FPSController>().enabled = false;
         interacting = true;
        }
        else {
            helpText.SetActive(false);
             player.GetComponent<FPSController>().enabled = true;
         interacting = false;
        }
    }
}