using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    public static int currentDay = 1;
    public int maxDays = 2;
    public GameObject[] DailyContexts;
    private GameObject CurrentContext;

    public void StartDay(){
        if (currentDay >= 1 && currentDay <= maxDays)
        {
            
        }
    }
    public void EndDay(){
        if(currentDay < maxDays)currentDay++;
        else EndGame();
    }
    private void EndGame(){}
    private void StartContext(){
        CurrentContext = DailyContexts[currentDay - 1]; 
        CurrentContext.SetActive(true);
    }

}
