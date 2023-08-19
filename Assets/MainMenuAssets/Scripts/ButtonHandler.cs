using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonHandler : MonoBehaviour
{
    public TextMeshProUGUI Textfield;

    public void SetText(string text)
    {
        Textfield.text = text;
    }
}
