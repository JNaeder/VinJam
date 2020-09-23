using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSpot : MonoBehaviour
{

    public GameObject textObject;

    private void Start()
    {
        textObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        textObject.SetActive(true);  
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        textObject.SetActive(false); 
    }
}
