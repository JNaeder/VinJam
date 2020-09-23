using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MenuManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject controlsScreen;

    [FMODUnity.EventRef]
    public string uiHoverSound, uiClickSound;

    public bool isPaused;

    LevelManager lm;
    WorldManager wm;

    private void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        wm = FindObjectOfType<WorldManager>();
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
                PlayUIClickSound();
                ShowPauseScreen();
            }
            else {
                PlayUIClickSound();
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
        wm.currentWorld = "A";
        lm.LoadSpecificScene(0);

    }

    public void PlayUIHoverSound() {
        FMODUnity.RuntimeManager.PlayOneShot(uiHoverSound);
    }

    public void PlayUIClickSound() {
        FMODUnity.RuntimeManager.PlayOneShot(uiClickSound);
    }
}
