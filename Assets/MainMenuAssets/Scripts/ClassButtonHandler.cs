using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ClassButtonHandler : MonoBehaviour
{
    public CharacterStats characterStats;

    public void OnBarbarianButtonClicked()
    {
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Barbarian);
    }

    public void OnArcherButtonClicked()
    {
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Archer);
    }

    public void OnWizardButtonClicked()
    {
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Wizard);
    }

    public void OnBardButtonClicked()
    {
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Bard);
    }

    public void OnFighterButtonClicked()
    {
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Fighter);
    }

    public void OnGiantButtonClicked()
    {
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Giant);
    }

    public void OnThiefButtonClicked()
    {
        characterStats.GenerateAndSaveRandomStats(CharacterStats.CharacterClass.Thief);
    }
}
