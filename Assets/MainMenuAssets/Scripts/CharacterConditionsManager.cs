using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class CharacterConditionsManager : MonoBehaviour
{
    public TMP_InputField nameInput;
    public Button[] classButtons;
    public Button nextButton;

    private string selectedClass = "";

    private void Start()
    {
        // Listeners for class buttons
        foreach (Button classButton in classButtons)
        {
            classButton.onClick.AddListener(() => OnClassButtonClicked(classButton.name));
        }

        // Listener for name input field
        nameInput.onValueChanged.AddListener(OnNameInputValueChanged);

        // Disabled the Next button initially
        nextButton.interactable = false;
    }

    private void OnClassButtonClicked(string className)
    {
        selectedClass = className;
        UpdateNextButtonInteractivity();
    }

    private void OnNameInputValueChanged(string newName)
    {
        UpdateNextButtonInteractivity();
    }

    private void UpdateNextButtonInteractivity()
    {
        // Enable the Next button if both a class is selected and a name is entered
        nextButton.interactable = !string.IsNullOrEmpty(selectedClass) && !string.IsNullOrEmpty(nameInput.text);
    }
}
