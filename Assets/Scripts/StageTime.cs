using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageTime : MonoBehaviour
{
    public float time;
    public GameObject timerObject;
    public GameObject enemiesManagerObject;
    TimerUI timerUI;
    EnemiesManager enemiesManager;

    private void Awake()
    {
        timerUI = timerObject.GetComponent<TimerUI>();
        enemiesManager = enemiesManagerObject.GetComponent<EnemiesManager>();
    }

    private void Update()
    {
        time+=Time.deltaTime;
        timerUI.UpdateTime(time);
        enemiesManager.setTime(time);
    }
}
