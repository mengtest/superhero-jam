using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public int score;
    private float time;

    private bool isPlaying = false;

    private Text counter;
    private Text counterGameOver;

    void Awake(){
        score = 0;
        time = 0;

        counter = GetComponent<Text>();
        counterGameOver = GameObject.Find("GameOverText").GetComponent<Text>();

        GameManager.StartGame += StartPlaying;
        GameManager.EndGame += UpdateGameOverCounter;
        GameManager.EndGame += StopPlaying;
    }

    void OnDestroy()
    {
        GameManager.StartGame -= StartPlaying;
        GameManager.EndGame -= UpdateGameOverCounter;
        GameManager.EndGame -= StopPlaying;
    }

	void Update () {

        if (isPlaying){
            time += Time.deltaTime;

            if (time >= 1.5f)
            {
                score++;
                UpdateCounter(score);

                time = 0;
            }
        }
    }

    private void StartPlaying()
    {
        isPlaying = true;
    }

    private void StopPlaying()
    {
        isPlaying = false;
    }

    private void UpdateGameOverCounter(){
        string text;

        if (score < 10)
        {
            text = string.Concat("00", score.ToString());
        }
        else if (score < 100)
        {
            text = "0" + score.ToString();
        }
        else if (score > 999)
        {
            text = "999";
        }
        else
        {
            text = score.ToString();
        }

        counterGameOver.text = text;
    }

    private void UpdateCounter(int score){
        string text;
        
        if (score < 10){
            text = string.Concat("00", score.ToString());
        }
        else if (score < 100)
        {
            text = "0" + score.ToString();
        }
        else if (score > 999)
        {
            text = "999";
        }
        else
        {
            text = score.ToString();
        }

        counter.text = text;
    }
}
