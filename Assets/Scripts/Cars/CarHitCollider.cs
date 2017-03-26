using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHitCollider : MonoBehaviour {
    /*
    private bool isPlaying;

    void Awake()
    {
        GameManager.StartGame += StartPlaying;
        GameManager.EndGame += StopPlaying;
    }

    void OnDestroy()
    {
        GameManager.StartGame -= StartPlaying;
        GameManager.EndGame -= StopPlaying;
    }

    void StartPlaying()
    {
        isPlaying = true;
    }

    void StopPlaying()
    {
        isPlaying = false;
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        //if (isPlaying) {
            if (col.name == "Player") {
                Debug.Log("hit");
                GameManager.EndGame();
            }
       // }
    }
}
