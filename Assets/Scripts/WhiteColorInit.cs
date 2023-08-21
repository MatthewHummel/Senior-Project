using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class WhiteColorInit : MonoBehaviour
{

    public Image generatedImage;

    // Start is called before the first frame update
    void Start()
    {
        generatedImage.color = Color.white;
    }
}
