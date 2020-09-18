using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    GameManager gM;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            gM.AddDiamond();
            Destroy(gameObject);

        }
    }
}
