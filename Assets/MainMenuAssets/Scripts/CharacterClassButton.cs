using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class CharacterClassButton : MonoBehaviour
{
    public CharacterStats.CharacterClass characterClass;

    public void SelectCharacterClass()
    {
        CharacterDataHolder.SelectedCharacterClass = characterClass;
    }
}
