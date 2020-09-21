using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelDoor : MonoBehaviour
{
    LevelManager lm;
    GameManager gm;
    WorldManager wm;
    WorldController wc;

    public Sprite openSprite, closedSprite;

    public bool isOpened;

    public SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        gm = FindObjectOfType<GameManager>();
        wm = FindObjectOfType<WorldManager>();
        wc = FindObjectOfType<WorldController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.totalDiamonds == gm.diamondsInLevel) {
            isOpened = true;
        }

        if (isOpened)
        {
            sp.sprite = openSprite;
        }
        else {
            sp.sprite = closedSprite;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (isOpened)
            {
                Debug.Log("End Level");
                SetWorldManager();
                lm.LoadNextScene();

            }
        }
    }


    void SetWorldManager() {
        if (wc.isWorldA) {
            wm.ChangeCurrentWorld("A");
        } else if (!wc.isWorldA) {

            wm.ChangeCurrentWorld("B");
        }

    }
}
