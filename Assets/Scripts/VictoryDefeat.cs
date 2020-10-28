using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryDefeat : MonoBehaviour
{

    public Button mainMenuButton;

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(LoadMainMenu);
    }
    private void Update()
    {
        Time.timeScale = 0;
    }
    private void LoadMainMenu()
    {
        Time.timeScale = 1;
        Scene scene = SceneManager.GetSceneAt(0);
        SceneManager.LoadScene(0);
    }
}
