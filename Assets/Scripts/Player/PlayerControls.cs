using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private Command buttonUpArrow, buttonDownArrow, buttonW, buttonS;

    void Start()
    {
        buttonUpArrow  = buttonW = new MoveUp(gameObject.GetComponent<Player>());
        buttonDownArrow = buttonS = new MoveDown(gameObject.GetComponent<Player>());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("up");
            buttonUpArrow.Execute();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("down");
            buttonDownArrow.Execute();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("w");
            buttonW.Execute();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("s");
            buttonS.Execute();
        }
    }
}
