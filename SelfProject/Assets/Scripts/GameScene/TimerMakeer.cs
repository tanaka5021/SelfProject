using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerMakeer : MonoBehaviour
{

    private Text timerText;
    private int minute;
    private float seconds;
    private float oldSeconds;
    //@Å‰‚ÌŠÔ
    private float startTime;

    void Start()
    {
        timerText = GetComponentInChildren<Text>();
        oldSeconds = 0;
        startTime = Time.time;
    }

    void Update()
    {

        //@Time.time‚Å‚ÌŠÔŒv‘ª
        seconds = Time.time - startTime;

        minute = (int)seconds / 60;

        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)(seconds % 60)).ToString("00");
        }
    }
}
