using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static int currentDay = 1;
    public int maxDays = 3;
    public GameObject[] DailyContexts; // This array will hold the canvases for each day's context.
    private GameObject CurrentContext;
    
    public GameObject InGameUI;
    private bool gameStarted = false;

    private void Start()
    {
        StartDay();
    }

    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.E))
        {
            TimeManagerScript.Instance.ResumeGame();
            gameStarted = true;
            CurrentContext.SetActive(false); // Hide the current day's context canvas.
            InGameUI.SetActive(true); // Activate the in-game UI.
        }
    }

    public void StartDay()
    {
        InGameUI.SetActive(false); // Deactivate the in-game UI at the start of the day.
        StartContext(); // Initialize the current day's context canvas.
    }

    public void EndDay()
    {
        TimeManagerScript.Instance.PauseGame();
        Debug.Log("Day ended");
        if (currentDay < maxDays) currentDay++;
        else EndGame();
    }

    private void EndGame() 
    {
        // You can add logic for ending the game here.
    }

    private void StartContext()
    {
        if (CurrentContext != null) 
            CurrentContext.SetActive(false); // Deactivate the previous day's context if any.
        gameStarted = false;
        TimeManagerScript.Instance.PauseGame();
        CurrentContext = DailyContexts[currentDay - 1];
        CurrentContext.SetActive(true); // Activate the current day's context.
    }
}
