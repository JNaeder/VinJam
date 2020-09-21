using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public ParticleSystem[] particleSystems;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StopSystems()
    {
        foreach (ParticleSystem p in particleSystems)
        {
            p.gameObject.SetActive(false);
        }


    }

    public void PlaySystem()
    {
        foreach (ParticleSystem p in particleSystems)
        {
            p.gameObject.SetActive(true);
        }
    }
}
