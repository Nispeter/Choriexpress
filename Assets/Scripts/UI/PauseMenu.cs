using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : GameManager
{
    public bool isGamePaused;
    public GameObject pauseCanvas;
    public GameObject inGameCanvas;
    void Start(){
        isGamePaused = false;
    }
    public override void GamePause(){
        base.GamePause();
        inGameCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isGamePaused=true;
    }
    public void ResumeGame(){
        Time.timeScale = 1f;
        inGameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGamePaused=false;
    }
}
