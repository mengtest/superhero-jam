using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour {

    public Superdude superdude;
    public Player player;

    public GameObject Skip;
    public GameObject Text_Help;
    public GameObject Text_Superdude;
    public GameObject Text_Cover;
    public GameObject Text_Exclamation;

    private IEnumerator cour;

    private bool introStarted = false;

    void Start(){
        cour = _TextSequence();
        Invoke("Intro", 4);
    }

    void Update()
    {
        if (introStarted) {
            if (Input.GetKey(KeyCode.Space)){
                GameManager.StartGame();
                superdude.gameObject.SetActive(true);

                StopCoroutine(cour);
                gameObject.SetActive(false);
            }
        }
    }

    void Intro(){
        introStarted = true;
        PlayerSetup();
        TextSequence();
    }

    void PlayerSetup(){
        player.gameObject.SetActive(true);
        player.Stand();
        player.MoveToStartingLane();
    }

    void TextSequence(){
        StartCoroutine(cour);        
    }

    IEnumerator _TextSequence()
    {
        Skip.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        Text_Help.SetActive(true);
        Skip.SetActive(false);
        yield return new WaitForSeconds(1f);

        player.Look();
        yield return new WaitForSeconds(0.2f);

        Text_Exclamation.SetActive(true);

        yield return new WaitForSeconds(2f);
        Text_Superdude.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        Text_Help.SetActive(false);

        yield return new WaitForSeconds(2.6f);
        Text_Superdude.SetActive(false);

        yield return new WaitForSeconds(0.3f);
        superdude.gameObject.SetActive(true);

        Text_Cover.SetActive(true);
        GameManager.StartGame();

        yield return new WaitForSeconds(2.5f);
        Text_Cover.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
