using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartGame : MonoBehaviour {

    Animator thisAnimator;
    Animator logoAnimator;
    CarManager carManager;

    bool pressed ;

    void Awake()
    {
        pressed = false;

        carManager = GameObject.Find("CarManager").GetComponent<CarManager>();

        thisAnimator = GetComponent<Animator>();
        logoAnimator = GameObject.Find("Logo").GetComponent<Animator>();
    }

	void Update () {
        if (!pressed) {
		    if (Input.GetKeyDown(KeyCode.Space))
            {
                pressed = true;
                carManager.StopSpawning();
                Invoke("FadeOut",2);

                SceneManager.LoadScene("Player", LoadSceneMode.Additive);
                GameObject.Find("GameManager").GetComponent<GameManager>().UnloadMenu();
            }
        }
    }

    void FadeOut()
    {
        thisAnimator.SetTrigger("Fade");
        logoAnimator.SetTrigger("Fade");
    }
}
