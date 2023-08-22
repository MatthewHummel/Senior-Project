using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ClassButtonHandler : MonoBehaviour
{
    // Reference to the CharacterStats script for generating and managing character stats
    public CharacterStats characterStats;

    // These functions are called when their respective class buttons are clicked
    public void OnBarbarianButtonClicked()
    {
        // Generate and save random stats for the Barbarian class
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Barbarian);
    }

    public void OnArcherButtonClicked()
    {
        // ... For the Archer class
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Archer);
    }

    public void OnWizardButtonClicked()
    {
        // ... For the Wizard class
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Wizard);
    }

    public void OnBardButtonClicked()
    {
        // ... For the Bard class
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Bard);
    }

    public void OnFighterButtonClicked()
    {
        // ... For the Fighter class
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Fighter);
    }

    public void OnGiantButtonClicked()
    {
        // ... For the Giant class
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Giant);
    }

    public void OnThiefButtonClicked()
    {
        // ... For the Thief class
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Thief);
    }
}
