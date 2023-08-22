using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterClassButton : MonoBehaviour
{
    // Field to hold a CharacterClass value from the CharacterStats class
    public CharacterStats.CharacterClass characterClass;

    // This function is called when the character class button is clicked
    public void SelectCharacterClass()
    {
        // Set the selected character class in the CharacterDataHolder
        CharacterDataHolder.SelectedCharacterClass = characterClass;
    }
}
