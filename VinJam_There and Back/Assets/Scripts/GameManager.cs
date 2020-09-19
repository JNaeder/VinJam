using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalDiamonds;
    public int diamondsInLevel;

    public string levelName;

    private void Start()
    {
        diamondsInLevel = FindObjectsOfType<Collectable>().Length;
    }


    public void AddDiamond() {
        totalDiamonds++;

    }
}
