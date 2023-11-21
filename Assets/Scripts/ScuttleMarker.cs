using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScuttleMarker : MonoBehaviour
{
   Transform player;
    private GameObject enemy; 
    Vector3 direction;
    float distance;

    private void Awake()
    {
         GameManager singleton = GameManager.instance;
          player= singleton.playerTransform;
    }

    public void SetTarget(GameObject t)
    {
        enemy = t;
    }

    private bool IsVisibleOnScreen()
    {
        if (Camera.main != null)
        {
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(enemy.transform.position);

            return (viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1);
        }

        return false;
    }


    void FixedUpdate()
    {
        if (enemy != null)
        {
            direction= enemy.transform.position-player.position;
            distance=Vector3.Distance(enemy.transform.position,player.position);
            RotateMarker();
            ScaleMarker();
            PositionMarker();
        }
        else
            Destroy(gameObject);
    }

    private void PositionMarker()
    {
        if (Camera.main != null)
        {
            Vector3 enemyWorldPosition = enemy.transform.position;
         
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
         
            Vector3 transformedEnemyPos = Camera.main.WorldToScreenPoint(enemy.transform.position);
            Vector3 transformedPlayerPos = Camera.main.WorldToScreenPoint(player.position);
        
            Vector3 newScreenPosition = transformedEnemyPos;
            int margin = 100; 
            newScreenPosition.x = Mathf.Clamp(newScreenPosition.x, margin, screenWidth - margin);
            newScreenPosition.y = Mathf.Clamp(newScreenPosition.y, margin, screenHeight - margin);
               
            transform.position = newScreenPosition;
        }
    }


    private void ScaleMarker()
    {
        Vector3 newScale =new Vector3(distance/15f,distance/15f,distance/15f);
     
        transform.localScale = newScale;
    
        if (IsVisibleOnScreen())
        {
            transform.localScale = Vector3.zero;
        }
    }



    private void RotateMarker()
    {
        float angle = Mathf.Atan2(direction.y, direction.x);
        transform.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg+90);
    }
}
