using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {

    private Text scoreText;
    private int score = 0;

	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
	}
	
	public void ScoreHit(int hitScore)
    {
        score += hitScore;
        scoreText.text = score.ToString();
    }
}
