using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

[XmlRoot("Player")]
public class XMLPlayer
{
    [XmlElement("name")]
    public string name;
    [XmlAttribute("player")]
    public bool isPlayer;
    [XmlIgnore]
    public int hitPoints;

    //The player's stats
    [XmlElement("PlayerStats")]
    public CharacterStats.Stats characterStats;

    public int damageTaken;
}
