using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIImageDeactivator : MonoBehaviour
{
    public ChangeImage changeImage;
    public GameObject uIImageInstantiator;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (changeImage.currentIndex >0){
            Debug.Log("More");
             uIImageInstantiator.SetActive(true); 
        } else { 
            Debug.Log("Less");
            uIImageInstantiator.SetActive(false);  }
    }
}
