using UnityEngine;
using UnityEngine.SceneManagement; // For reloading the scene

public class CollideTeleport : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Restart the current scene immediately
            RestartScene();
        }
    }

    private void RestartScene()
    {
        // Get the current scene and reload it
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}