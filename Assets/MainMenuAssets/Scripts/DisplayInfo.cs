using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    // Reference to the TextMeshProUGUI component in the Unity Editor for displaying player name
    public TextMeshProUGUI display_player_name;
    public TextMeshProUGUI Textfield;

    public void Awake()
    {
        // Display the player name from the CharacterScene instance on the assignedd TextMeshProUGUI
        display_player_name.text = CharacterScene.characterscene.player_name;
    }
}
