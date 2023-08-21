using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMLDeserializer : MonoBehaviour
{

    private string filePath;

    private void Start()
    {
        filePath = Application.dataPath + "/TextOutput/player.xml";

        XMLPlayer player = XMLOp.Deserialize<XMLPlayer>(filePath);
        Debug.Log(player.name);
    }
}
