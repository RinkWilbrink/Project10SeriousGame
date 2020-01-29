using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private string GameSceneName;
    public void StartGame()
    {
        SceneManager.LoadScene(GameSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
