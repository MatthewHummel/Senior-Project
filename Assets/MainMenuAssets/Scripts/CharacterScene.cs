using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CharacterScene : MonoBehaviour
{
    public static CharacterScene characterscene;
    public TMP_InputField inputField;

    public string player_name;

    public void Awake()
    {
        if (characterscene == null)
        {
            characterscene = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName()
    {
        player_name = inputField.text;

        SceneManager.LoadSceneAsync("GeneratedCharacterStuff");
    }

    public void SetPlayerClass(string input)
    {
       // ButtonHandler.Textfield = input;
    }
}
