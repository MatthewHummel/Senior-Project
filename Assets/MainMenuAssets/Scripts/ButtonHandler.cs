using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public TextMeshProUGUI Textfield;

    public void SetText(string className)
    {
        Textfield.text = "" + className;
        OnClassButtonClicked(className);
    }

    public void OnClassButtonClicked(string className)
    {
        PlayerPrefs.SetString("SelectedClass", className);
    }

    public void LoadMainGameScene()
    {
        SceneManager.LoadSceneAsync("MainGame");
    }

}