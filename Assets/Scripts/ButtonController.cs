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
        int randomNumber = Random.Range(1, 21);
        diceText.text = "Rolled: " + randomNumber;

        //Append to text file on a new line
        File.AppendAllText(filePath, "Dice Roll: " + randomNumber + "\n");
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