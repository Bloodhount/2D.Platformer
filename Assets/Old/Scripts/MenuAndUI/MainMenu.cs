using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("MainMenu");
        //SceneManager.GetSceneByName("MainMenu");

      //  var audioGO = GameObject.Find("SettingsMenu");
        //if (audioGO.TryGetComponent(out AudioMixer audioMixer))
        //{
        //    // audioMixer 
        //    DontDestroyOnLoad(audioMixer);
        //}

        // DontDestroyOnLoad();
    }

    public void QuitGame()
    {
        Debug.Log("QQQQUIT!!!");
        Application.Quit();
    }

}

