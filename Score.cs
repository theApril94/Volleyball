using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI scoreBoardRight;
    [SerializeField] public TextMeshProUGUI scoreBoardLeft;

    private int scoreRight = 0;
    private int scoreLeft = 0;


    private void Start()
    {
        UpdateRightScoreBoard();
        UpdateLeftScoreBoard();
    }

    public void RightScorePoint()
    {
        scoreRight++;
        UpdateRightScoreBoard();   
    }

    public void LeftScorePoint()
    {
        scoreLeft++;
        UpdateLeftScoreBoard();
    }

    public void UpdateRightScoreBoard()
    { 
        scoreBoardRight.text = scoreRight.ToString();
    }

    public void UpdateLeftScoreBoard()
    {
        scoreBoardLeft.text = scoreLeft.ToString();
    }
}
