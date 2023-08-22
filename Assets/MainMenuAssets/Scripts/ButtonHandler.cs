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
        // Set the text of the Textfield to the provided class name
        Textfield.text = "" + className;

        // Call the OnClassButtonClicked function with the provided class name as an argument
        OnClassButtonClicked(className);
    }

    // This function sets the selected class name using PlayerPrefs
    public void OnClassButtonClicked(string className)
    {
        PlayerPrefs.SetString("SelectedClass", className);
    }

    public void LoadMainGameScene()
    {
        // Load the "MainGame" scene asynchronously, allowing for better performance
        SceneManager.LoadSceneAsync("MainGame");
    }

}