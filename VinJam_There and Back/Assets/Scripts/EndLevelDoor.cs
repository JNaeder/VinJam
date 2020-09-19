using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour
{
    LevelManager lm;
    GameManager gm;

    public bool isOpened;
    public Color closedColor, openedColor;

    SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        gm = FindObjectOfType<GameManager>();

        sp = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.totalDiamonds == gm.diamondsInLevel) {
            isOpened = true;
        }

        if (isOpened)
        {
            sp.color = openedColor;
        }
        else {
            sp.color = closedColor;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (isOpened)
            {
                Debug.Log("End Level");
                lm.LoadNextScene();
            }
        }
    }
}
