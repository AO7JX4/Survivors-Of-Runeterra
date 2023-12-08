using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject player;
    public GameObject weapons;
    public GameObject yasAA;
    public GameObject enemies;

    public void EndGame()
    {
        Time.timeScale = 0f;

        weapons.SetActive(false);
        yasAA.SetActive(false);
        enemies.SetActive(false);

        DropOnDestroy.OnSceneChange();

        gameOverPanel.SetActive(true);
    }
}
