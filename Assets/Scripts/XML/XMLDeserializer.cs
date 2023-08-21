using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMLDeserializer : MonoBehaviour
{
    //file path for the xml file
    private string filePath;

    private void Start()
    {
        //create path to file
        filePath = Application.dataPath + "/TextOutput/player.xml";

        //run Deserialize method from the XMLOp class
        XMLPlayer player = XMLOp.Deserialize<XMLPlayer>(filePath);


        //Debug name to test. 
        Debug.Log("Player name: " + player.name);
    }
}
