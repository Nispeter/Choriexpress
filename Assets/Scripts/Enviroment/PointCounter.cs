using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public static PointCounter Instance { get; private set; }

    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject scoreCanvas;
    public GameObject looseCanvas;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddScore(1000);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    public void SubScore(int points)
    {
        score -= points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text =  score+"$";
        }
    }

    public void EndCount()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ActivateScoreCanvas();
    }
    public void ActivateScoreCanvas()
    {
        if(score >= 5000)
            scoreCanvas.SetActive(true);
        else 
            looseCanvas.SetActive(true);

    }
}



