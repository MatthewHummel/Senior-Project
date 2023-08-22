using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class CharacterScene : MonoBehaviour
{
    public static CharacterScene characterscene;
    public TMP_InputField inputField;

    // Store the player's name
    public string player_name;

    public void Awake()
    {
        // Check if the characterscene instance has been assigned
        if (characterscene == null)
        {
            // If not assigned, sets to this instance and prevents the GameObject from being destroyed on scene change
            characterscene = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this GameObject
            Destroy(gameObject);
        }
    }

    // This function is called when the player's name is set and a scene is loaded
    public void SetPlayerName()
    {
        // Get the text from the input field and store it as the player's name
        player_name = inputField.text;

        SceneManager.LoadSceneAsync("GeneratedCharacterStuff");
    }

    public void SetPlayerClass(string input)
    {

    }
}
