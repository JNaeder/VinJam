using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour
{
    public GameObject platformsA, platformsB;
    public GameObject backgroundA, backgroundB;

    bool isWorldA;

    TransitionManager transMang;
    // Start is called before the first frame update
    void Start()
    {
        transMang = FindObjectOfType<TransitionManager>();


        SwitchWorld("A");
        isWorldA = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWorlds();
    }


    void ChangeWorlds() {
        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            Debug.Log("Change World!");
            isWorldA = !isWorldA;
            transMang.PlayTransitionClip();


            if (isWorldA)
            {
                SwitchWorld("A");
            }
            else {
                SwitchWorld("B");
            }

        }


    }


    void SwitchWorld(string letter) {
        if (letter == "A")
        {
            platformsA.SetActive(true);
            backgroundA.SetActive(true);

            platformsB.SetActive(false);
            backgroundB.SetActive(false);
        }
        else if (letter == "B") {
            platformsA.SetActive(false);
            backgroundA.SetActive(false);

            platformsB.SetActive(true);
            backgroundB.SetActive(true);
        }

    }
}
