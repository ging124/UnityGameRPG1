using System;
using UnityEngine;
using TMPro;

public class PlayingClock : MonoBehaviour
{
    public TMP_Text timeText;
    public float time;
    public float minute;
    public float second;

    static public PlayingClock instance;

    void Awake()
    {
        PlayingClock.instance = this;
        timeText = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        DisplayTime(time);
    }

    void DisplayTime(float time)
    {
        time += 1;
        minute = Mathf.FloorToInt(time / 60);
        second = Mathf.FloorToInt(time % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
