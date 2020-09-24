using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class LevelLoader : MonoBehaviour
{
    private void Update()
    {
        if (FMODUnity.RuntimeManager.HasBanksLoaded) {
            StartCoroutine(LoadScene(1));
        }
    }

    IEnumerator LoadScene(int sceneNum) {
        Debug.Log("Load Scene");
        SceneManager.LoadScene(sceneNum);
        yield return null;
    }
}
