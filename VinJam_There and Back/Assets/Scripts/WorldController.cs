using UnityEngine;
using FMODUnity;

public class WorldController : MonoBehaviour
{
    public GameObject platformsA, platformsB;
    public GameObject backgroundA, backgroundB;
    public GameObject camEffectA, camEffectB;
    
    [Range(0f,1f)]
    public float timeSpeed;
    [Range(0f,3f)]
    public float pauseTimer;

    [FMODUnity.EventRef]
    public string changeWorldsSound;

    [HideInInspector]
    public bool isWorldA;
    bool isPaused;

    float _pausedTime;

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

        PauseTime();
    }


    void ChangeWorlds() {
        if (Input.GetButtonDown("Fire1")) {
            FMODUnity.RuntimeManager.PlayOneShot(changeWorldsSound);
            isPaused = true;
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
            camEffectA.SetActive(true);

            platformsB.SetActive(false);
            backgroundB.SetActive(false);
            camEffectB.SetActive(false);
        }
        else if (letter == "B") {
            platformsA.SetActive(false);
            backgroundA.SetActive(false);
            camEffectA.SetActive(false);

            platformsB.SetActive(true);
            backgroundB.SetActive(true);
            camEffectB.SetActive(true);
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
