using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    bool paused;
    public GameObject panel;

    public Button pauseButton;

    public Button playButton;


    public Button exitButton;

    public Button mainMenuButton;
    private void LoadMainMenu()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetSceneAt(0);
        SceneManager.LoadScene(0);
    }
    private void Awake()
    {
        pauseButton.onClick.AddListener(PauseTheGame);
        playButton.onClick.AddListener(Unpause);
        exitButton.onClick.AddListener(ExitGame);
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }

    private void ExitGame()
    {
        Application.Quit();
    }


    void PauseTheGame()
    {
        paused = true;

    }

    private void StopPlay()
    {
        Time.timeScale = 0;
        panel.SetActive(true);
        pauseButton.interactable = false;
    }

    void Unpause()
    {
        paused = false;
    }

    private void ResumePlay()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        pauseButton.interactable = true;
    }

    private void Update()
    {
        if (paused)
        {
            StopPlay();
        }
        else if (!paused)
        {
            ResumePlay();
        }
    }
}
