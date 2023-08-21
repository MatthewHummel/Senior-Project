using System.IO;
using System.Xml.Serialization;

public class XMLOp
{
    //method for serializing
    public static void Serialize(object item, string path)
    {
        XmlSerializer serializer= new XmlSerializer(item.GetType());
        StreamWriter writer = new StreamWriter(path);
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();
    }
    //method for deserializing. Using "T" to allow any type.
    public static T Deserialize<T>(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(path);
        T deserialized = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return deserialized;
    }


}
