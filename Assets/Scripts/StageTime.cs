using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    TimerUI timerUI;
    EnemiesManager enemiesManager;

    private void Awake()
    {
        timerUI=FindObjectOfType<TimerUI>();    
        enemiesManager = FindObjectOfType<EnemiesManager>();
    }

    private void Update()
    {
        time+=Time.deltaTime;
        timerUI.UpdateTime(time);
        enemiesManager.setTime(time);
    }
}
