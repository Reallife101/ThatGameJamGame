using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load the main game scene
    public void PlayGame()
    {
        SceneManager.LoadScene("Sample Scene");
    }

    // Quit the application
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }
}
