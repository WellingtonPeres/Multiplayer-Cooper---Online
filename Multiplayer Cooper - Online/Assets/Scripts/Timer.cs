using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 10;
    [SerializeField] private bool timerIsRunning = false;

    [SerializeField] private TextMeshProUGUI timeText;

    private void Start()
    {
        timerIsRunning = true;
    }

    void Update()
    {
        TimeGame();
    }

    private void TimeGame()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTimeShowText(timeRemaining);
            }
            else
            {
                Debug.Log("Executar algum comando aqui!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    private void DisplayTimeShowText(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
