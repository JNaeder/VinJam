using UnityEngine;
using FMODUnity;

public class MusicManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string musicEvent;

    FMOD.Studio.EventInstance musicInst;

    public static MusicManager inst;


    private void Awake()
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

    // Start is called before the first frame update
    void Start()
    {

        musicInst = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        musicInst.start();
    }

    // Update is called once per frame
    void Update()
    {
        SetWorldParameter();
    }


    void SetWorldParameter() {
        if (FindObjectOfType<WorldController>().isWorldA)
        {
            musicInst.setParameterByName("World", 0);
        }
        else {
            musicInst.setParameterByName("World", 1);
        }

    }
}
