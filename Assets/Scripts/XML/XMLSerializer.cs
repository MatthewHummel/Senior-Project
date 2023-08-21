using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using Unity.VisualScripting;

public class XMLSerializer : MonoBehaviour
{
    private string filePath;
    private string playerName;

    private void Start()
    {
        //get player name
        playerName = CharacterScene.characterscene.player_name;

        //Location for the XML file
        filePath = Application.dataPath + "/TextOutput/player.xml";

        //test data to write. attempts to write a string, int, and bool
        XMLPlayer player = new XMLPlayer();
        player.name = playerName;
        player.isPlayer = true;
        player.hitPoints = 30;
        player.damageTaken = 3;

        //calls the serialize function, held in the XMLOp class.
        //This is what creates and writes the XML file, which
        //will be created in the "text output" folder.
        XMLOp.Serialize(player, filePath);
    }

}
