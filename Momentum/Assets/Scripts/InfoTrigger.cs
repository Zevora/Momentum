using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InfoTrigger : MonoBehaviour {

    public static bool GameIsPaused = false;

    //To trigger pause
    void OnTriggerEnter()
    {

    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

}
