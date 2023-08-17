using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
public string firstlevel;

public GameObject optionsScreen;

    void Start()
    {

    }

    void Update()
    {

    }

      public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    public void ClosedOptions()
    {
        optionsScreen.SetActive(false);
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
