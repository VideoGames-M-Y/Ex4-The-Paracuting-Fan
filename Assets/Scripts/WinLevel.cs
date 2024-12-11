using UnityEngine;
using UnityEngine.SceneManagement; // For loading the next level

public class WinLevel : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string characterTag = "Player"; // Tag to identify the character
    [SerializeField] private float timeToWin = 2f;           // Time the character needs to stay on the zone

    private float stayTimer = 0f;
    private bool isCharacterOnZone = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(characterTag))
        {
            isCharacterOnZone = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(characterTag))
        {
            isCharacterOnZone = false;
            stayTimer = 0f; // Reset timer when character leaves the zone
        }
    }

    void Update()
    {
        if (isCharacterOnZone)
        {
            stayTimer += Time.deltaTime;

            if (stayTimer >= timeToWin)
            {
                NextLevel();
            }
        }
    }

    private void NextLevel()
    {
        Debug.Log("You Win! Moving to the next level...");
        // Load the next scene (next level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}