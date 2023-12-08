using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] WaveData stage;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] GameObject player;
    private int stageIndex = 0;
    float time = 0;

    public void setTime(float t)
    {
        time = t;
    }

    private void Update()
    {
        if (stageIndex > stage.events.Count - 1)
            return;
        if (time >= stage.events[stageIndex].minute * 60f + stage.events[stageIndex].second)
        {
            for (int j = 0; j < stage.events[stageIndex].amount; j++)
            {
                SpawnEnemy();
            }
            stageIndex++;
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = GenerateRandomPosition();
        position += player.transform.position;

        GameObject newEnemy = Instantiate(stage.events[stageIndex].enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<EnemyBehaviour>().SetTarget(player);
        newEnemy.transform.parent = transform;
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();
        float f = UnityEngine.Random.value > 0.5f ? -1f : 1f;
        if (UnityEngine.Random.value > 0.5f)
        {
            position.x = UnityEngine.Random.Range(-spawnArea.x, spawnArea.x);
            position.y = spawnArea.y * f;
        }
        else
        {

            position.x = spawnArea.x * f;
        }


        position.z = 0f;

        return position;
    }
}
