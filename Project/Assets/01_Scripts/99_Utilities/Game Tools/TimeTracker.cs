using System;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{
    private float startTime;
    public TextMeshPro timerText;

    public TMP_Text timerTextUI;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        int days = (int)(elapsedTime / 86400);
        int hours = (int)((elapsedTime % 86400) / 3600);
        int minutes = (int)((elapsedTime % 3600) / 60);
        int seconds = (int)(elapsedTime % 60);

        if(timerText != null)
            timerText.SetText(string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds));

        if(timerTextUI != null)
            timerTextUI.SetText(string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hours, minutes, seconds));
    }
}