﻿using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameManager gM;
    LevelManager lm;

    public TMP_Text diamondNum;
    public TMP_Text levelName;

    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<GameManager>();
        lm = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        diamondNum.text = gM.totalDiamonds.ToString() + "/" + gM.diamondsInLevel.ToString();
        levelName.text =  lm.FindCurrentSceneNum() + ": " + gM.levelName;

    }


    
}
