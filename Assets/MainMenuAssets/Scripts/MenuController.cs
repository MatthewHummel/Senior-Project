using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{
    // Fields for volume settings
    [Header("Voulme Setting")]
    [SerializeField] private TMP_Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private float defaultVolume = 5.0f; 

    public string firstlevel;

    // Reference to the options screen
    public GameObject optionsScreen;

    void Start()
    {

    }

    void Update()
    {

    }

    // Function to load a scene by its name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    // Function to open the options screen
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    // Function to close the options screen
    public void ClosedOptions()
    {
        optionsScreen.SetActive(false);
    }
    // Function to handle the exit button
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    // Function to set the volume based on the volume slider value
    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
    }

    // Function to apply the current volume setting
    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }

    // Function to reset settings to default audio volume
    public void ResetButton(string MenuType)
    {
        if (MenuType == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeTextValue.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }
    }
}
