using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(QuitTheGame);
    }
    void QuitTheGame()
    {
        Application.Quit();
    }
}
