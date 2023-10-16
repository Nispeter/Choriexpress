using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : GameManager
{
    public bool isGamePaused;
    public GameObject pauseCanvas;
    public GameObject inGameCanvas;
    void Start(){
        isGamePaused = TimeManagerScript.Instance.IsGamePaused;
    }
    public override void GamePause(){
        base.GamePause();
        inGameCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        TimeManagerScript.Instance.PauseGame();
    }
    public void ResumeGame(){
        Time.timeScale = 1f;
        inGameCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        TimeManagerScript.Instance.ResumeGame();
    }
}
