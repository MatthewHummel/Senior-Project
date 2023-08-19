using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplaySelectedClass : MonoBehaviour
{
    public TMP_Text selectedClassText;

    void Start()
    {
        if (PlayerPrefs.HasKey("SelectedClass"))
        {
            string selectedClass = PlayerPrefs.GetString("SelectedClass");
            selectedClassText.text = "" + selectedClass;
        }
    }
}
