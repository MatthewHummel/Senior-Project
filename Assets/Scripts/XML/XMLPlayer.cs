using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class XMLPlayer
{
    [XmlElement("n")]
    public string name;

    public bool isPlayer;

    public int hitPoints;

    public int baseDamage;
}
