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
        if(GetComponent<Button>()!=null)
        GetComponent<Button>().onClick.AddListener(LoadTheScene);
    }
    void LoadTheScene()
    {
        SceneManager.LoadScene(indexToLoad);
    }

}
