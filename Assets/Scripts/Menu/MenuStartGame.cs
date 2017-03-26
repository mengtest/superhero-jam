using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStartGame : MonoBehaviour {

    Animator thisAnimator;
    Animator logoAnimator;

    bool pressed ;

    void Awake()
    {
        pressed = false;

        thisAnimator = GetComponent<Animator>();
        logoAnimator = GameObject.Find("Logo").GetComponent<Animator>();

        GameManager.StartIntro += DoStuffs;
    }

    void OnDestroy()
    {
        GameManager.StartIntro -= DoStuffs;
    }

	void Update () {
        if (!pressed) {
		    if (Input.GetKeyDown(KeyCode.Space))
            {
                pressed = true;
                GameManager.StartIntro();
            }
        }
    }

    void DoStuffs() { //im sorry
        Invoke("FadeOut", 2);
        SceneManager.LoadScene("Player", LoadSceneMode.Additive);
        GameObject.Find("GameManager").GetComponent<GameManager>().UnloadMenu();
    }

    void FadeOut()
    {
        thisAnimator.SetTrigger("Fade");
        logoAnimator.SetTrigger("Fade");
    }
}
