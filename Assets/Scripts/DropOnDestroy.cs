using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
 
    [SerializeField] GameObject dropItemPrefab;
    [SerializeField] [Range(0f,1f)] float chance=1f;

    static bool isQuitting=false;
    
    public static void OnSceneChange()
    {
        isQuitting = true;
    }
    private void OnApplicationQuit()
    {
        isQuitting=true;
    }

    private void OnDestroy()
    {
        if(isQuitting) return;
        
        if(Random.value<chance)
        {
            Transform t=Instantiate(dropItemPrefab).transform;
            t.position=transform.position;
        }
        
    }
}
