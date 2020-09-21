using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void LoadNextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void LoadSpecificScene(int sceneNum) {

        SceneManager.LoadScene(sceneNum);
    }


    public void QuitGame() {
        Application.Quit();

    }


    public int FindNumbeOfLevels() {
        int numOfLevels = SceneManager.sceneCountInBuildSettings;
        return numOfLevels;

    }

    public int FindCurrentSceneNum() {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        return sceneNum;
    }
}
