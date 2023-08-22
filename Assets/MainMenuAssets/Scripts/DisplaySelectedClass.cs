using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplaySelectedClass : MonoBehaviour
{
    // Reference to the TMP_Text component in Unity for display
    public TMP_Text selectedClassText;

    void Start()
    {
        // Check if the "SelectedClass" player preference exists
        if (PlayerPrefs.HasKey("SelectedClass"))
        {
            // Retrieve the selected class from player preferences
            string selectedClass = PlayerPrefs.GetString("SelectedClass");
            // Display the selected class on selectedClassText TMP box
            selectedClassText.text = "" + selectedClass;
        }
    }
}
