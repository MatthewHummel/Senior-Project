using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ButtonController : MonoBehaviour
{
    private string filePath;
    public TMPro.TextMeshProUGUI displayText;
    public TMPro.TextMeshProUGUI diceText;
    public TMPro.TextMeshProUGUI displayLast;
    public TMPro.TMP_InputField InputField;


    public int GeneratedRandomNumber;


    private void Start()

    {
        //Location for text file, Create directions.txt file
        filePath = Application.dataPath + "/TextOutput/directions.txt";

        //If file exists, write to file"
        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "");
        }
    }

    //Record direction method, append to text file on a new line
    public void RecordDirection(string direction)
    {
        File.AppendAllText(filePath, direction + "\n");
    }

    //D20 generate random number Method from 1 to 20
    public void GenerateRandomNumber()
    {
        GeneratedRandomNumber = Random.Range(1, 21);
        diceText.text = "Rolled: " + GeneratedRandomNumber;

        //Append to text file on a new line
        File.AppendAllText(filePath, "Dice Roll: " + GeneratedRandomNumber + "\n");
    }


    //Display last line method if file exists, find last line by subtracting the total with the length, else display error no file
    public void DisplayLastLine()
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length > 0)
            {
                string lastLine = lines[lines.Length - 1];
                displayLast.text = lastLine;
            }
            else
            {
            displayLast.text = "Text file is empty.";
            }
        }
        else
        {
            displayLast.text = "Text file does not exist.";
        }
    }

    //Display file content method, if file exists display all. Else display error no file.
    public void DisplayTextFileContents()
    {
        if (File.Exists(filePath))
        {
            string fileContents = File.ReadAllText(filePath);
            displayText.text = fileContents;
        }
        else
        {
            displayText.text = "Text file does not exist.";
        }
    }

    //When send button is clicked, take input field data and append to text file
    public void OnSendButtonClicked()
    {
        string inputData = InputField.text;
        File.AppendAllText(filePath, "User Input: " + inputData + "\n");
    }


    //Direction methods
    public void OnUpButtonClicked()
    {
        RecordDirection("Move up");
    }

    public void OnDownButtonClicked()
    {
        RecordDirection("Move down");
    }

    public void OnLeftButtonClicked()
    {
        RecordDirection("Move left");
    }

    public void OnRightButtonClicked()
    {
        RecordDirection("Move right");
    }
    //Dice click method
    public void OnDiceButtonClicked()
    {
        GenerateRandomNumber();
    }
    //Display button method
    public void OnDisplayButtonClicked()
    {
        DisplayTextFileContents();
    }
}