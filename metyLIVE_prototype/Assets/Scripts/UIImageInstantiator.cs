using UnityEngine;
using UnityEngine.UI;

public class UIImageInstantiator : MonoBehaviour
{
    public Image sourceImage;        // The UI Image to copy the sprite from
    public GameObject imagePrefab;   // The prefab of the UI Image to instantiate
    public Canvas parentCanvas;      // The canvas to use as a reference for scaling and positioning
    public float minY = -360f;       // Minimum Y position for allowing instantiation

    // Call this method to instantiate a new UI image at the mouse position
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (sourceImage == null || imagePrefab == null) return; // Check if source image and prefab are set

            // Convert the mouse position to world position in the context of the canvas
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvas.transform as RectTransform, Input.mousePosition, parentCanvas.worldCamera, out pos);

            // Check if the Y position of the mouse is above the minimum Y
            if (pos.y < minY)
            {
                return; // Do not instantiate if the mouse Y is below minY
            }

            // Instantiate the image prefab
            GameObject newImageObj = Instantiate(imagePrefab, parentCanvas.transform);
            newImageObj.transform.localPosition = new Vector3(pos.x, pos.y, 0); // Set the local position to the converted mouse position

            Image newImage = newImageObj.GetComponent<Image>(); // Get the Image component

            if (newImage != null)
            {
                newImage.sprite = sourceImage.sprite; // Set the sprite of the new image to that of the source image
            }
        }
    }
}