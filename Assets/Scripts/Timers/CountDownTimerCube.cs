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
    float lastSecond = 0f;
    public AudioSource SFX;
    private int digit, digit2;
    public AudioClip chains1, chains2, spooky, doorslam;
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
        float currentTimeInSeconds = Mathf.Floor(CurrentTime); // Redondea al segundo más cercano
        
        //print(CurrentTime);
        if (currentTimeInSeconds != lastSecond && CurrentTime>5)
        {   
            digit = Random.Range(0,1000);
            if(digit <= 10){
                digit2 = Random.Range(0,5);
                switch (digit2){
                    case 1: 
                        SFX.clip = chains1;
                        SFX.Play();
                        break;
                    case 2: 
                        SFX.clip = chains2;
                        SFX.Play();
                        break;
                    case 3: 
                        SFX.clip = spooky;
                        SFX.Play();
                        break;
                    case 4: 
                        SFX.clip = doorslam;
                        SFX.Play();
                        break;
                }
            }
            // Ha pasado un segundo, ejecuta tu código aquí

            lastSecond = currentTimeInSeconds; // Actualiza el valor de referencia para el segundo actual
        }
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