using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceasarSuccess : MonoBehaviour
{ public GameObject object1;
    public GameObject object2;
    public Canvas canvasToActivate;

    void Update()
    {
        // Check if both GameObjects are assigned
        if (object1 == null || object2 == null)
        {
            Debug.LogError("Please assign both GameObjects in the inspector");
            return;
        }

        // Retrieve Y-axis rotation angles of both GameObjects
        float yAngleObject1 = object1.transform.eulerAngles.y;
        float yAngleObject2 = object2.transform.eulerAngles.y;

        // Compare angles with a tolerance to avoid floating point imprecision
        if (Mathf.Abs(yAngleObject1 - yAngleObject2) < 0.1f) // 0.1 can be adjusted based on needed precision
        {
            // Activate the canvas if the angles are close enough
            if (canvasToActivate != null && !canvasToActivate.gameObject.activeInHierarchy)
            {
                canvasToActivate.gameObject.SetActive(true);
            }
        }
        else
        {
            // Optionally, deactivate the canvas if angles do not match
            if (canvasToActivate != null && canvasToActivate.gameObject.activeInHierarchy)
            {
                canvasToActivate.gameObject.SetActive(false);
            }
        }
    }
}
