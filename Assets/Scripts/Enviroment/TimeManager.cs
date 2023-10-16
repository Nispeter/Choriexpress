using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    public static TimeManagerScript Instance { get; private set; }

    public bool IsGamePaused { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        IsGamePaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
}
