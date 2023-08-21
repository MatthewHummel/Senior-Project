using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DisplaySavedImage : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        string imagePath = Path.Combine(Application.persistentDataPath, "TextOutput/GeneratedImage.png");
        Debug.Log($"Image Path: {imagePath}"); // Debug the image path

        if (File.Exists(imagePath))
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(imageBytes);

            // Convert the Texture2D to a Sprite
            Sprite sprite = Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );

            // Set the sprite to the Image component
            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("Image file does not exist.");
        }
    }
}
