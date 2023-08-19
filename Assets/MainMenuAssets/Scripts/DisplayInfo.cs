using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayInfo : MonoBehaviour
{
    public TextMeshProUGUI display_player_name;
    public TextMeshProUGUI Textfield;

    public void Awake()
    {
        display_player_name.text = CharacterScene.characterscene.player_name;
    }
}
