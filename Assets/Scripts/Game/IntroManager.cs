using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

	void Awake () {
        Invoke("Intro", 4);
	}

    void Intro()
    {
        GameManager.StartGame();
    }
}
