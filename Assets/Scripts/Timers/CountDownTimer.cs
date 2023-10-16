using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    float CurrentTime = 0f;
    float StartingTime = 10f;

    [SerializeField] TMP_Text CountdownText;
    [SerializeField] private Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = StartingTime;
        Slider.maxValue = CurrentTime;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime -= 1 * Time.deltaTime;
        //print(CurrentTime);
        CountdownText.text = CurrentTime.ToString("F1");
        Slider.value = CurrentTime;
        if(CurrentTime <= 5) CountdownText.color = Color.red;
        if(CurrentTime <= 0)
        {
            CurrentTime = 0f;
            Slider.value = CurrentTime;
        }
    }
}
