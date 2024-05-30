using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ceasarMovement : MonoBehaviour
{public float[] snapAngles; // Array of angles to snap to
    private bool dragging = false;
    private Vector3 lastMousePosition;
    private float rotationSpeed = 15.0f; // Adjust rotation sensitivity

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the mouse is over the GameObject when clicked
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.transform == transform)
            {
                dragging = true;
                lastMousePosition = Input.mousePosition;
            }
        }

        if (dragging)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 delta = Input.mousePosition - lastMousePosition;
                float angle = delta.x * rotationSpeed * Time.deltaTime;
                transform.Rotate(0, angle, 0, Space.World);
                lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                dragging = false;
                float currentAngle = transform.eulerAngles.y;
                float nearestAngle = FindNearestAngle(currentAngle);
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, nearestAngle, transform.eulerAngles.z);
            }
        }
    }

    private float FindNearestAngle(float currentAngle)
    {
        float closestAngle = snapAngles[0];
        float minDifference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, closestAngle));

        foreach (float angle in snapAngles)
        {
            float difference = Mathf.Abs(Mathf.DeltaAngle(currentAngle, angle));
            if (difference < minDifference)
            {
                minDifference = difference;
                closestAngle = angle;
                Debug.Log(closestAngle);
            }
        }

        return closestAngle;
        
    }
    
}
