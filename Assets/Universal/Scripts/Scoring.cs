using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
//Using TMP;

public class Scoring : JMC
{

    public int highScore = 0;
    public int score = 150;

    [Header("UI Elements")]
    public CanvasGroup scoreCanvas;
    public Text scoreText;
    public Text highScoreText;
    public Text scoreMessage;

    private void Start()
    {
        FadeCanvas(scoreCanvas, 0, 0);
        GetHighScore();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            CheckScore();
        }
        //PlayerPrefs.DeleteKey("HighScore")
    }

    void CheckScore()
    {
        GetHighScore();
        highScoreText.text = highScore.ToString();
        scoreText.text = score.ToString();

        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            scoreMessage.text = "Congratulations! \n You got a new High Score!";
            //TMP <color = green> - changes the color of the text
            scoreMessage.gameObject.transform.DOScale(Vector3.one * 1.2f, 2).SetLoops(-1);

        }
        else
        {
            scoreMessage.text = "Too Bad! \n Better luck next time!";
            scoreMessage.gameObject.transform.DOScale(Vector3.one * 0.8f, 2).SetLoops(-1);
        }

        FadeCanvas(scoreCanvas, 1, 1);


    }

    void GetHighScore()
    {
        highScore = PlayerPrefs.GetInt("HighScore");
        Debug.Log("The high score is " + highScore);
    }

}
