using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject controlsScreen;

    public bool isPaused;

    LevelManager lm;

    private void Start()
    {
        lm = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInput();
    }



    void CheckForInput() {
        if (Input.GetButtonDown("Cancel")) {
            isPaused = !isPaused;
            if (isPaused)
            {

                ShowPauseScreen();
            }
            else {
                HidePauseScreen();
            }
        
        }


    }

    public void SetTimeScale(float _timeScale) {
        Time.timeScale = _timeScale;

    }



    public void ShowPauseScreen() {
        SetTimeScale(0);
        pauseScreen.SetActive(true);
        controlsScreen.SetActive(false);
    }

    public void HidePauseScreen() {
        SetTimeScale(1);
        pauseScreen.SetActive(false);
        controlsScreen.SetActive(false);
        isPaused = false;

    }

    public void ShowControlsScreen() {
        pauseScreen.SetActive(false);
        controlsScreen.SetActive(true);

    }

    public void BackToMainMenu() {
        lm.LoadSpecificScene(0);

    }
}
