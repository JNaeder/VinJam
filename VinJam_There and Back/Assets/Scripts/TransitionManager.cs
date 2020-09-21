using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionManager : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    public void PlayTransitionAClip() {
        anim.Play("TransitionA");

    }

    public void PlayTransitionBClip()
    {
        anim.Play("TransitionB");

    }
}
