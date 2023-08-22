using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterDataHolder : MonoBehaviour

{
    // Field to hold the selected character class from the CharacterStats class
    public static CharacterStats.CharacterClass SelectedCharacterClass;

    // Field to hold the selected character stats from the CharacterStats class
    public static CharacterStats.Stats SelectedCharacterStats;

    void Awake()
    {
        // Prevent the GameObject from being destroyed when a new scene is loaded
        DontDestroyOnLoad(gameObject);
    }
}

