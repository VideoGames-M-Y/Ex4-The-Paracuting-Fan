//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameOnSpace : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
}
