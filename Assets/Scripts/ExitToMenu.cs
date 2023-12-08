using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitToMenu : MonoBehaviour
{
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        DeleteAll();
        SceneManager.LoadScene("MainMenu");
    }
    public void DeleteAll()
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(o);
        }
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("EnemyProjectile"))
        {
            Destroy(o);
        }
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("DropObjects"))
        {
            Destroy(o);
        }
    }
}
