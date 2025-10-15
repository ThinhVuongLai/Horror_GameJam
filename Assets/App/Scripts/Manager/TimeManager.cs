using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] private float realSecondToDay = 900f; // 60 real seconds to 1 game day

    private bool isRunTime = true;

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
            NextDay();
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
