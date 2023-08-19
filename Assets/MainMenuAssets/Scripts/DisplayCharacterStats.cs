using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DisplayCharacterStats : MonoBehaviour
{
    public TextMeshProUGUI statsText;
    public CharacterStats characterStats;

    void Start()
    {
        CharacterStats.Stats selectedStats = CharacterDataHolder.SelectedCharacterStats;

        statsText.text = "Vitality: " + selectedStats.vitality +
            "\nDefense: " + selectedStats.defense +
            "\nStrength: " + selectedStats.strength +
            "\nIntelligence: " + selectedStats.intelligence +
            "\nDexterity: " + selectedStats.dexterity +
            "\nCharisma: " + selectedStats.charisma +
            "\nSneak: " + selectedStats.sneak;
    }
}
