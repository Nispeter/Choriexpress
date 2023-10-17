using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static int currentDay = 1;
    public int maxDays = 3;
    public GameObject[] DailyContexts;
    private GameObject CurrentContext;

    public GameObject InGameUI;
    private bool gameStarted = false;

    public GameObject player;
    public Transform playerSpawnPosition;
    public CountDownTimerCube timer;

    private void Start()
    {
        currentDay = 1;
        StartDay();
    }

    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.F))
        {
            TimeManagerScript.Instance.ResumeGame();
            gameStarted = true;
            CurrentContext.SetActive(false);
            InGameUI.SetActive(true);
        }
    }

    private void EliminateExistingPackages()
    {
        GameObject[] existingPackages = GameObject.FindGameObjectsWithTag("Package");
        foreach (GameObject package in existingPackages)
        {
            Destroy(package);
        }
    }

    private void ResetPlayerPosition()
    {   
        if (player != null)
        {
            player.transform.position = playerSpawnPosition.position;
            player.transform.rotation = Quaternion.identity;
        }
        else
        {
            Debug.LogError("Player reference is missing in DayManager!");
        }
    }

    public void StartDay()
    {
        ResetPlayerPosition();
        EliminateExistingPackages();
        InGameUI.SetActive(false);
        StartContext();
    }
    public void EndDay()
    {
        TimeManagerScript.Instance.PauseGame();
        Debug.Log("Day ended");

        if (timer != null)
        {
            timer.ResetTimer(); // Assuming you have a ResetTimer method in CountDownTimerCube
        }

        if (currentDay < maxDays)
        {
            currentDay++;
            StartDay(); // Start the game again if it's not the final day
        }
        else
        {
            EndGame();
        }
    }
    private void EndGame()
    {
                    TimeManagerScript.Instance.PauseGame();
                    InGameUI.SetActive(false);
                    PointCounter.Instance.EndCount();
    }

    private void StartContext()
    {
        if (CurrentContext != null)
            CurrentContext.SetActive(false);
        gameStarted = false;
        TimeManagerScript.Instance.PauseGame();
        CurrentContext = DailyContexts[currentDay - 1];
        CurrentContext.SetActive(true);
    }
}
