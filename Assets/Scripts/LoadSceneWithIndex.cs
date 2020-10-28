using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadSceneWithIndex : MonoBehaviour
{
    public int indexToLoad;
    void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadTheScene);
    }
    void LoadTheScene()
    {
        SceneManager.LoadScene(indexToLoad);
    }

}
