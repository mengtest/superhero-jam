using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Superdude : MonoBehaviour {

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();

        GameManager.EndGame += FlyOut; 
    }

    void OnDestroy()
    {
        GameManager.EndGame -= FlyOut;
    }

    public void FlyOut()
    {
        animator.SetTrigger("FlyOut");
    }
}
