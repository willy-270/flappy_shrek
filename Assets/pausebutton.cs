using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class pausebutton : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public GameObject score;

    public AudioMixerGroup music;
    public AudioMixerGroup sfx;

    public static bool isPaused = false;

    public void Update() {
         if(Input.GetKeyDown(KeyCode.Escape)) 
         {
            if(isPaused == false)
            {
                pauseGame();
            } 
            else 
            {
                unPauseGame(); 
            }
        }
    }

    public void pauseGame() {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        pauseBtn.SetActive(false);
        score.SetActive(false);

        isPaused = true;

        music.audioMixer.SetFloat("MusicVol", -15f);
        music.audioMixer.SetFloat("lowcutoff", 630f);

        sfx.audioMixer.SetFloat("SfxVol", -500f);
        
        Debug.Log("paused");
    }
    
    public void unPauseGame() {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseBtn.SetActive(true);
        score.SetActive(true);

        isPaused = false;
        
        music.audioMixer.SetFloat("MusicVol", 0f);
        music.audioMixer.SetFloat("lowcutoff", 22000f);

        sfx.audioMixer.SetFloat("SfxVol", 0);
        
        Debug.Log("unpaused");
    }
}
