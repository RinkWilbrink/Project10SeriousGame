using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject PauzeMenuUI;
    private bool pauzed = false;


    private void Update()
    {
        PauzeInput();
    }

    void PauzeInput()
    {
        if (pauzed == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                PauzeTheGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
            {
                ResumeTheGame();
            }

        }
    }

    void PauzeTheGame()
    {
        PauzeMenuUI.SetActive(true);
        Time.timeScale = 0;
        pauzed = true;
    }

    void ResumeTheGame()
    {
        PauzeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pauzed = false;
    }
}
