using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    public int score;
    private float time;

    private Text counter;

    void Awake(){
        score = 0;
        time = 0;

        counter = GetComponent<Text>();
    }

	void Update () {
        time += Time.deltaTime;

        if (time >= 1.5f) {
            score++;
            UpdateCounter(score);

            time = 0;
        }
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
