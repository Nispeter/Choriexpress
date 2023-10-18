using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimerCube : MonoBehaviour
{
    float CurrentTime = 0f;
    [SerializeField] private float StartingTime = 30f;

    [SerializeField] DayManager dayManager;
    [SerializeField] TMP_Text CountdownText;
    // [SerializeField] private Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        CountdownText.color = Color.white;
        CurrentTime = StartingTime;
        if (dayManager == null)
        {
            dayManager = FindObjectOfType<DayManager>();
            if (dayManager == null)
            {
                Debug.LogWarning("No DayManager found in the scene!");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        //print(CurrentTime);
        CountdownText.text = CurrentTime.ToString("F1");
        // Slider.value = CurrentTime;
        if (CurrentTime <= 5) CountdownText.color = Color.red;
        if (!TimeManagerScript.Instance.IsGamePaused && CurrentTime <= 0)
        {
            CurrentTime = 0f;
            dayManager.EndDay();
        }
    }

    public void ResetTimer()
    {
        CurrentTime = StartingTime; // Reset the timer to its starting value
        CountdownText.color = Color.white; // Reset the text color, assuming default is white
    }
}