using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : SingletonMono<TimeManager>
{
    [SerializeField] private float realSecondToDay = 900f; // 60 real seconds to 1 game day

    private bool isRunTime = true;

    public bool IsRunTime
    {
        get { return isRunTime; }

        set { isRunTime = value; }
    }

    private float currentSecound = 0f;
    private int currentDay = 1;

    private void Update()
    {
        if (!isRunTime)
        {
            return;
        }

        currentSecound += Time.deltaTime;
        if (currentSecound >= realSecondToDay)
        {
            if (currentDay >= 3)
            {
                GameManager.I.SetPauseGame(true);
                ScriptableObjectController.I.ShowFinishAction.RunAction();
            }
            else
            {
                NextDay();
            }
        }
        else
        {
            ScriptableObjectController.I.UpdateDateTimeTextAction.RunAction(GetDayTimeString());
        }
    }

    private void NextDay()
    {
        currentSecound = 0f;
        currentDay++;
    }

    private string GetDayTimeString()
    {
        float dayProgress = currentSecound / realSecondToDay;
        int totalMinutes = Mathf.FloorToInt(dayProgress * 1440); // 1440 minutes in a day
        int hours = totalMinutes / 60;
        int minutes = totalMinutes % 60;
        return string.Format("Day {0} - {1:D2}:{2:D2}", currentDay, hours, minutes);
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        isRunTime = focusStatus;
    }
}
