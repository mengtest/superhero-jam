using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    private Command buttonUpArrow, buttonDownArrow, buttonW, buttonS, buttonSpace;
    Player player;

    void Start()
    {
        player = gameObject.GetComponent<Player>();

        buttonUpArrow  = buttonW = new MoveUp(player);
        buttonDownArrow = buttonS = new MoveDown(player);
        buttonSpace = new Jump(player);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            buttonUpArrow.Execute();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            buttonDownArrow.Execute();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            buttonW.Execute();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            buttonS.Execute();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            buttonSpace.Execute();
        }
    }
}
