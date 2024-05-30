using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image targetImage;       // The Image component where the sprite will be displayed
    public Sprite[] images;         // Array of sprites to cycle through
    public int currentIndex = 0;   // Current index in the sprite array

    // Call this method when the button is pressed
    public void ImageChange()
    {
        if (images.Length == 0) return; // If no images are provided, do nothing

        currentIndex++; // Move to the next image
        if (currentIndex >= images.Length) // Check if the index exceeds the array length
        {
            currentIndex = 0; // Reset index if it exceeds the length
        }

        targetImage.sprite = images[currentIndex]; // Change the sprite of the Image component
    }
}