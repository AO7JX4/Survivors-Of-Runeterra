using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    
    Animator animator;

    public float horizontal;
    public float death;
    public float attack;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetFloat("Horizontal",horizontal);
        animator.SetFloat("Death", death);
    }
}
