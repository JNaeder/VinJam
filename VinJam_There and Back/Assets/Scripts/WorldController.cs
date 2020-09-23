using UnityEngine;
using FMODUnity;

public class WorldController : MonoBehaviour
{
    public GameObject platformsA, platformsB;
    public GameObject backgroundA, backgroundB;
    public GameObject camEffectA, camEffectB;
    public GameObject lightA, lightB, playerLight;
    
    [Range(0f,1f)]
    public float timeSpeed;
    [Range(0f,3f)]
    public float pauseTimer;

    [FMODUnity.EventRef]
    public string changeWorldsSound;

    
    public bool isWorldA;
    bool isPaused;

    float _pausedTime;

    TransitionManager transMang;
    WorldManager wm;
    MenuManager mm;

    // Start is called before the first frame update
    void Start()
    {
        transMang = FindObjectOfType<TransitionManager>();
        wm = FindObjectOfType<WorldManager>();
        mm = FindObjectOfType<MenuManager>();

        if (wm.currentWorld == "A")
        {
            SwitchWorld("A");
            isWorldA = true;
        }
        else if (wm.currentWorld == "B") {
            SwitchWorld("B");
            isWorldA = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeWorlds();
        if (!mm.isPaused)
        {
            PauseTime();
        }
    }


    void ChangeWorlds() {
        if (Input.GetButtonDown("Fire1")) {
            FMODUnity.RuntimeManager.PlayOneShot(changeWorldsSound);
            isPaused = true;
            isWorldA = !isWorldA;
            if (isWorldA)
            {
                transMang.PlayTransitionAClip();
            }
            else {
                transMang.PlayTransitionBClip();
            }


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
        wm.currentWorld = letter;

        if (letter == "A")
        {
            platformsB.SetActive(false);
            backgroundB.SetActive(false);
            camEffectB.SetActive(false);
            lightB.SetActive(false);

            platformsA.SetActive(true);
            backgroundA.SetActive(true);
            camEffectA.SetActive(true);
            lightA.SetActive(true);

            playerLight.SetActive(true);
        }
        else if (letter == "B") {
            platformsA.SetActive(false);
            backgroundA.SetActive(false);
            camEffectA.SetActive(false);
            lightA.SetActive(false);

            platformsB.SetActive(true);
            backgroundB.SetActive(true);
            camEffectB.SetActive(true);
            lightB.SetActive(true);

            playerLight.SetActive(false);
        }

    }


    public void PauseTime() {
        
            if (isPaused)
            {
                Time.timeScale = timeSpeed;
                _pausedTime = Time.realtimeSinceStartup;
                isPaused = false;
            }

        if (Time.realtimeSinceStartup > _pausedTime + pauseTimer)
        {
            Time.timeScale = 1;
        }

        }



    
}
