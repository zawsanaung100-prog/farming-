using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject optionPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenOptions()
    {
        optionPanel.SetActive(true);
    }

    public void CloseOptions()
    {
        optionPanel.SetActive(false);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}