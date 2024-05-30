using UnityEngine;

public class BounceEffect : MonoBehaviour
{
    private Vector3 originalScale;
    private float timePressed = 0;
    private bool isPressed = false;
    private float maxDipScale = 0.2f; // Maximum dip as a percentage of original size

    void Start()
    {
        // Save the original scale of the GameObject
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isPressed = true;
            timePressed = 0; // Reset the timer when mouse button is pressed
        }

        if (isPressed)
        {
            timePressed += Time.deltaTime; // Increase time pressed
            float currentDip = Mathf.Lerp(1.0f, 1.0f - maxDipScale, timePressed/2);
            transform.localScale = new Vector3(originalScale.x * currentDip, originalScale.y * currentDip, originalScale.z * currentDip);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            // Bounce back effect, stronger bounce the longer the press
            float bounceStrength = timePressed; // Directly use the time pressed
            transform.localScale = originalScale; // Reset scale to original
            GetComponent<Rigidbody>().AddForce(Vector3.up * bounceStrength * bounceStrength * 1000); // Adjust force magnitude as necessary
        }
    }
}

