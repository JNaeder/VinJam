using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    Tree[] allTrees;

    WorldController wc;
    WorldManager wm;

    public string currentWorld;

    // Start is called before the first frame update
    void Start()
    {
        wc = FindObjectOfType<WorldController>();
        wm = FindObjectOfType<WorldManager>();
        allTrees = GetComponentsInChildren<Tree>();


        if (wm.currentWorld == "A")
        {
            ChangeTrees("A");
            currentWorld = "A";

        }
        else {
            ChangeTrees("B");
            currentWorld = "B";

        }

        currentWorld = wm.currentWorld;

    }

    // Update is called once per frame
    void Update()
    {

        if (wm.currentWorld != currentWorld) {
            if (wm.currentWorld == "A")
            {
                ChangeTrees("A");
                currentWorld = "A";

            }
            else {
                ChangeTrees("B");
                currentWorld = "B";
            }

        }



    }


    void ChangeTrees(string world) {

        foreach (Tree t in allTrees)
        {
            if (world == "A")
            {
                t.WorldA();

            }
            else if (world == "B") {
                t.WorldB();

            }

        }



    }
}
