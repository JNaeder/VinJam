using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{

    public string currentWorld;

    public static WorldManager inst;

    // Start is called before the first frame update
    void Start()
    {
        if (inst == null)
        {
            inst = this;
        }
        else {
            Destroy(this);
        }

        DontDestroyOnLoad(this);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCurrentWorld(string newWorld) {
        currentWorld = newWorld;


    }
}
