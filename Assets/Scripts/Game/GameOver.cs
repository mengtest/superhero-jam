using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    public float delay;
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        GameManager.EndGame += FlyIn;
    }

    void OnDestroy()
    {
        GameManager.EndGame -= FlyIn;
    }

    void FlyIn()
    {
        Invoke("_FlyIn", delay);
    }

    void _FlyIn()
    {
        animator.SetTrigger("FlyIn");
    }
}
