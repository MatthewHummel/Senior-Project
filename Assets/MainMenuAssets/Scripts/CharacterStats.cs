using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    // Defining different character classes
    public enum CharacterClass { Barbarian, Wizard, Archer, Giant, Bard, Fighter, Thief }

    // Structure defining a range of stat values
    [System.Serializable]
    public struct StatsRange
    {
        public int minStatValue;
        public int maxStatValue;
    }

    // Declare different stats ranges for various character classes including the default value
    public StatsRange defaultRange = new StatsRange { minStatValue = 2, maxStatValue = 6 };
    public StatsRange barbarianRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange wizardRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange archerRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange giantRange = new StatsRange { minStatValue = 8, maxStatValue = 10 };
    public StatsRange bardRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange fighterRange = new StatsRange { minStatValue = 3, maxStatValue = 7 };
    public StatsRange thiefRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };

    // Structure defining various character stats
    [System.Serializable]
    public struct Stats
    {
        public int vitality;
        public int defense;
        public int strength;
        public int intelligence;
        public int dexterity;
        public int charisma;
        public int sneak;
    }

    // Function to generate random stats based on the selected character class
    public Stats GenerateRandomStats(CharacterClass characterClass)
    {
        // Create a Stats instance to hold the generated stats
        Stats randomStats;

        // Use a switch statement to determine the character class and assign corresponding stat ranges
        switch (characterClass)
        {
            // Case for Barbarian class with unique stat values and ranges
            case CharacterClass.Barbarian:
                randomStats.vitality = Random.Range(barbarianRange.minStatValue, barbarianRange.maxStatValue + 1);
                randomStats.defense = Random.Range(barbarianRange.minStatValue, barbarianRange.maxStatValue + 1);
                randomStats.strength = Random.Range(barbarianRange.minStatValue, barbarianRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            // Case for Wizard class with unique stat values and ranges
            case CharacterClass.Wizard:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(wizardRange.minStatValue, wizardRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            // Case for Archer class with unique stat values and ranges
            case CharacterClass.Archer:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(archerRange.minStatValue, archerRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            // Case for Giant class with unique stat values and ranges
            case CharacterClass.Giant:
                randomStats.vitality = Random.Range(giantRange.minStatValue, giantRange.maxStatValue + 1);
                randomStats.defense = Random.Range(giantRange.minStatValue, giantRange.maxStatValue + 1);
                randomStats.strength = Random.Range(5, giantRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(1, 4);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(1, 4);
                break;

            // Case for Giant class with unique stat values and ranges
            case CharacterClass.Bard:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(bardRange.minStatValue, bardRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            // Case for Fighter class with unique stat values and ranges
            // The Fighter class essentially has normal default range except stats are generated between 3-7
            case CharacterClass.Fighter:
                randomStats.vitality = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.defense = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.strength = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                break;

            // Case for Thief class with unique stat values and ranges
            case CharacterClass.Thief:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(thiefRange.minStatValue, thiefRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(thiefRange.minStatValue, thiefRange.maxStatValue + 1);
                break;

            // Case for Default class values
            default:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;
        }

        return randomStats;
    }

    // Function to generate random stats, save them, and display them
    public void GenerateAndSaveRandomStats(CharacterClass selectedClass)
    {
        // Generate random stats for the selected character class
        Stats randomStats = GenerateRandomStats(selectedClass);

        // Save the generated stats in the CharacterDataHolder
        CharacterDataHolder.SelectedCharacterStats = randomStats;

        // Debugger log for the generated stats
        Debug.Log(selectedClass.ToString() + " Stats: " +
            "Vitality: " + randomStats.vitality +
            ", Defense: " + randomStats.defense +
            ", Strength: " + randomStats.strength +
            ", Intelligence: " + randomStats.intelligence +
            ", Dexterity: " + randomStats.dexterity +
            ", Charisma: " + randomStats.charisma +
            ", Sneak: " + randomStats.sneak);
    }
}