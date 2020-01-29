using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauzeMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject PauzeMenuUI;
    public void Resume()
    {
        Time.timeScale = 1f;
        PauzeMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
