using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayCharacterStats : MonoBehaviour
{
    public TextMeshProUGUI statsText;

    // Reference to the CharacterStats script for accessing selected character stats
    public CharacterStats characterStats;

    void Start()
    {
        // Retrieve the selected character stats from CharacterDataHolder
        CharacterStats.Stats selectedStats = CharacterDataHolder.SelectedCharacterStats;

        // Text to display the selected character's stats
        statsText.text = "Vitality: " + selectedStats.vitality +
            "\nDefense: " + selectedStats.defense +
            "\nStrength: " + selectedStats.strength +
            "\nIntelligence: " + selectedStats.intelligence +
            "\nDexterity: " + selectedStats.dexterity +
            "\nCharisma: " + selectedStats.charisma +
            "\nSneak: " + selectedStats.sneak;
    }
}
