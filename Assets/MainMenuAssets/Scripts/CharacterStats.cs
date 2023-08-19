using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterStats : MonoBehaviour
{
    public enum CharacterClass { Barbarian, Wizard, Archer, Giant, Bard, Fighter, Thief }

    [System.Serializable]
    public struct StatsRange
    {
        public int minStatValue;
        public int maxStatValue;
    }

    public StatsRange defaultRange = new StatsRange { minStatValue = 2, maxStatValue = 6 };
    public StatsRange barbarianRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange wizardRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange archerRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange giantRange = new StatsRange { minStatValue = 8, maxStatValue = 10 };
    public StatsRange bardRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };
    public StatsRange fighterRange = new StatsRange { minStatValue = 3, maxStatValue = 7 };
    public StatsRange thiefRange = new StatsRange { minStatValue = 5, maxStatValue = 10 };

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

    public Stats GenerateRandomStats(CharacterClass characterClass)
    {
        Stats randomStats;

        switch (characterClass)
        {
            case CharacterClass.Barbarian:
                randomStats.vitality = Random.Range(barbarianRange.minStatValue, barbarianRange.maxStatValue + 1);
                randomStats.defense = Random.Range(barbarianRange.minStatValue, barbarianRange.maxStatValue + 1);
                randomStats.strength = Random.Range(barbarianRange.minStatValue, barbarianRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            case CharacterClass.Wizard:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(wizardRange.minStatValue, wizardRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            case CharacterClass.Archer:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(archerRange.minStatValue, archerRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            case CharacterClass.Giant:
                randomStats.vitality = Random.Range(giantRange.minStatValue, giantRange.maxStatValue + 1);
                randomStats.defense = Random.Range(giantRange.minStatValue, giantRange.maxStatValue + 1);
                randomStats.strength = Random.Range(5, giantRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(1, 4);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(1, 4);
                break;

            case CharacterClass.Bard:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(bardRange.minStatValue, bardRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                break;

            case CharacterClass.Fighter:
                randomStats.vitality = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.defense = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.strength = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(fighterRange.minStatValue, fighterRange.maxStatValue + 1);
                break;

            case CharacterClass.Thief:
                randomStats.vitality = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.defense = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.strength = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.intelligence = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.dexterity = Random.Range(thiefRange.minStatValue, thiefRange.maxStatValue + 1);
                randomStats.charisma = Random.Range(defaultRange.minStatValue, defaultRange.maxStatValue + 1);
                randomStats.sneak = Random.Range(thiefRange.minStatValue, thiefRange.maxStatValue + 1);
                break;

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

    void Start()
    {
        CharacterClass[] allClasses = (CharacterClass[])System.Enum.GetValues(typeof(CharacterClass));

        foreach (CharacterClass characterClass in allClasses)
        {
            Stats randomStats = GenerateRandomStats(characterClass);
            Debug.Log(characterClass.ToString() + " Stats: " +
                "Vitality: " + randomStats.vitality +
                ", Defense: " + randomStats.defense +
                ", Strength: " + randomStats.strength +
                ", Intelligence: " + randomStats.intelligence +
                ", Dexterity: " + randomStats.dexterity +
                ", Charisma: " + randomStats.charisma +
                ", Sneak: " + randomStats.sneak);
        }
    }
}