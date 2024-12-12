using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicController : MonoBehaviour
{
    [SerializeField] private AudioClip sceneMusic; // Music for this scene

    private void Start()
    {
        if (SoundManager.Instance != null && sceneMusic != null)
        {
            SoundManager.Instance.PlayMusic(sceneMusic);
        }
    }
}