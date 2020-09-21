using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class EndLevelDoor : MonoBehaviour
{
    LevelManager lm;
    GameManager gm;
    WorldManager wm;
    WorldController wc;

    public Sprite openSprite, closedSprite;

    public bool isOpened;

    public SpriteRenderer sp;

    [FMODUnity.EventRef]
    public string endLevelSound;


    int numberOfLevels;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        gm = FindObjectOfType<GameManager>();
        wm = FindObjectOfType<WorldManager>();
        wc = FindObjectOfType<WorldController>();
        numberOfLevels = lm.FindNumbeOfLevels();
        
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
                if (lm.FindCurrentSceneNum() == lm.FindNumbeOfLevels() - 2) {
                    
                    wc.isWorldA = true;
                }
                SetWorldManager();
                FMODUnity.RuntimeManager.PlayOneShot(endLevelSound);
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
