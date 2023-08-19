using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterDataHolder : MonoBehaviour

{
    public static CharacterStats.CharacterClass SelectedCharacterClass;
    public static CharacterStats.Stats SelectedCharacterStats;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}

