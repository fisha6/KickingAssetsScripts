using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerUI1;
    [SerializeField] private TextMeshProUGUI timerUI2;
    private float elapsedTime = 0;
    private float minutes;
    private float seconds;

    void Update()
    {
        if (!GameStats.instance.gameWon || !GameStats.instance.gameLost)
        {
            elapsedTime += Time.deltaTime;
            DrawTimer(elapsedTime);
        }
    }

    void DrawTimer(float time)
    {
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        string val = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerUI1.text = val;
        timerUI2.text = val;
    }
}
