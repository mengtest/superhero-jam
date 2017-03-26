using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHitCollider : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player"){
            Debug.Log("hit");
            GameManager.EndGame();
            //if hit call the static del
        }
    }
}
