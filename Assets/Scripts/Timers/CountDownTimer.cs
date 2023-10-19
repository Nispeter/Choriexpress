using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    float CurrentTime = 0f;
    public float StartingTime = 5f;

    [SerializeField] TMP_Text CountdownText;
    [SerializeField] private Slider Slider;
    public AudioSource SFX;

    public AudioClip Alarm;
    public AudioClip Tick;
    float lastSecond = 0f;
    private bool AlarmTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
        CountdownText.color = Color.black;
        Slider.maxValue = CurrentTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        //print(CurrentTime);
        float currentTimeInSeconds = Mathf.Floor(CurrentTime); // Redondea al segundo más cercano
        
        if (currentTimeInSeconds != lastSecond)
        {
            // Ha pasado un segundo, ejecuta tu código aquí
            SFX.clip = Tick;
            SFX.Play();

            lastSecond = currentTimeInSeconds; // Actualiza el valor de referencia para el segundo actual
        }
        CountdownText.text = CurrentTime.ToString("F1");
        Slider.value = CurrentTime;
        if(CurrentTime <= 5 ) {
            CountdownText.color = Color.red;
            
            if(!AlarmTriggered){
                SFX.clip = Alarm;
                SFX.Play();
                AlarmTriggered = true;
            }
            
        }
        
        if(CurrentTime <= 0)
        {   
            GetComponentInParent<Package>().FailedCurse();
            CurrentTime = StartingTime;
            Slider.value = CurrentTime;
        }
    }

}
