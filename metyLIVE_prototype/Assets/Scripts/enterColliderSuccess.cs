using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterColliderSuccess : MonoBehaviour
{
    public GameObject activeCanvas;
    void Start(){
        Debug.Log("I am alive");
    }
    void OnCollisionEnter(Collision other){
        Debug.Log("success");
        if(other.gameObject.CompareTag("Apple")){
            Debug.Log("success");
            activeCanvas.SetActive(true);
            
        }
    }
}
