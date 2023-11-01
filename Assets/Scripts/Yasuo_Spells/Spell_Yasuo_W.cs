using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Yasuo_W : MonoBehaviour
{
    
    //Time left for the object to live
    [SerializeField] float timeToDestroy=10f;
    Vector3 direction;
    [SerializeField] float glideSpeed=8f;
    [SerializeField] [Range(0f,1f)] float glideTime=0f;
    bool isWallMoving=true;

    private void Update()
    {
        if(isWallMoving)
        {
            transform.position+=direction*glideSpeed*Time.deltaTime;
        }
             
        timeToDestroy-=Time.deltaTime;
        glideTime-=Time.deltaTime;
        if(glideTime<0f)
            isWallMoving=false;

        if (timeToDestroy < 0f)
        {

            Destroy(gameObject);

        }
    }

    //Check collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyProjectile p=collision.GetComponent<EnemyProjectile>();
        if (p!=null)
        {
            Destroy(p.gameObject);
        }
    }

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);

        if(dir_x<0)
        {
            Vector3 scale=transform.localScale;
            scale.x=scale.x*-1;
            transform.localScale=scale;
        }
    }
}
