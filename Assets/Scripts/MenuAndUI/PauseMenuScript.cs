using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;



public class PauseMenuScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public AudioMixer audioMixer;

    public GameObject pauseMenuUI;
    public GameObject MainMenuUI;

    private AudioSource audioSource;
    private float audioVol = 0.8f;

    public void Start()
    {
        pauseMenuUI.SetActive(false);
        MainMenuUI = GameObject.FindWithTag("MainMenuUI");
        //audioSource = GetComponent<AudioSource>();
        //audioSource.volume = 0.5f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // (Input.GetButtonDown("Cancel")) 
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
                //MainMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);

            }
            //Application.Quit();
            //audioSource.volume = audioVol;
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.01f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void SetVolumeInGame(float volume)
    {
        audioVol = volume;
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }

    public void LoadMenu()
    {
        Debug.Log("LoadMenu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        SceneManager.GetSceneByName("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Time.timeScale = 0.01f;

        Application.Quit();
    }
}
