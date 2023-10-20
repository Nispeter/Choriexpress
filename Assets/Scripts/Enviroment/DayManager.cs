using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static DayManager Instance { get; private set; }
    public static int currentDay = 1;
    public int maxDays = 3;
    public GameObject[] DailyContexts;
    private GameObject CurrentContext;

    public GameObject InGameUI;
    private bool gameStarted = false;

    public GameObject player;
    public Transform playerSpawnPosition;
    public CountDownTimerCube timer;
    public AudioSource SFX;
    public AudioClip honk;
    public GameObject dailyCursePrefab; 

    private GameObject curseInstance;
    private DailyCurse dailyCurse;

    private void Start()
    {
        curseInstance = Instantiate(dailyCursePrefab);
        dailyCurse = curseInstance.GetComponent<DailyCurse>();
        currentDay = 1;
        StartDay();

    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (!gameStarted && Input.GetKeyDown(KeyCode.F))
        {
            TimeManagerScript.Instance.ResumeGame();
            gameStarted = true;
            CurrentContext.SetActive(false);
            InGameUI.SetActive(true);
            SFX.clip = honk;
            SFX.Play();
        }
    }

    private GameObject[] existingPackages;
    private void EliminateExistingPackages()
    {
        existingPackages = GameObject.FindGameObjectsWithTag("Package");
        foreach (GameObject package in existingPackages)
        {
            Destroy(package);
        }
    }

    private void ResetPlayerPosition()
    {
        if (player != null)
        {
            CharacterController charController = player.GetComponent<CharacterController>();
            if (charController != null)
            {
                charController.enabled = false; // disable character controller
                player.transform.position = playerSpawnPosition.position;
                player.transform.rotation = playerSpawnPosition.rotation;
                charController.enabled = true; // enable character controller
            }
            else
            {
                player.transform.position = playerSpawnPosition.position;
                player.transform.rotation = Quaternion.identity;
            }
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
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
        dailyCurse.StopCurrentCurse();
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
        
        if (dailyCurse)
            dailyCurse.ActivateCurse(currentDay);
    }
}