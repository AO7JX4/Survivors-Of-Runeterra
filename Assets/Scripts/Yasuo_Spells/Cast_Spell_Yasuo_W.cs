using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cast_Spell_Yasuo_W : MonoBehaviour
{
    [SerializeField] GameObject windwallPrefab;
    float currentCoolDown=0;
    [SerializeField] float coolDown=5f;
    [SerializeField] Image img; 


    PlayerMove playerMove;

    private void Awake()
    {
        img.fillAmount=0;
        playerMove = GetComponentInParent<PlayerMove>();
    }

    void Update()
    {
        currentCoolDown-=Time.deltaTime;
        img.fillAmount-=1/coolDown*Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space) && currentCoolDown<=0)
        {
           SpawnWindwall();
        }
            
    }

    private void SpawnWindwall()
    {
        img.fillAmount=1;
        currentCoolDown=coolDown;
        GameObject windwall=Instantiate(windwallPrefab);
        windwall.transform.position=transform.position;
        windwall.GetComponent<Spell_Yasuo_W>().SetDirection(playerMove.lastHorizontalVector,0f);
    }
}
