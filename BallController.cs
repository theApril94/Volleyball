using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BallController : MonoBehaviour
{

    [SerializeField] private LayerMask playerCastLayerMask;
    [SerializeField] private LayerMask groundLayerMask;

    private float circleCastRadius = 1f;

    private Rigidbody2D ballRigidbody2D;
    private CircleCollider2D circleCollider2D;

    private Score score;


    private void Start()
    {

        circleCollider2D = GetComponent<CircleCollider2D>();

        ballRigidbody2D = GetComponent<Rigidbody2D>();
        ballRigidbody2D.bodyType = RigidbodyType2D.Static;

        score = FindObjectOfType<Score>();

        BallPositionOnStart();

    }

    private void Update()
    {
        if (IsHitted())
        {
            ballRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private bool IsHitted()
    {
        RaycastHit2D CircleRaycastHit2d = Physics2D.CircleCast(circleCollider2D.bounds.center, circleCastRadius, Vector2.down, .1f, playerCastLayerMask);
        Debug.Log(CircleRaycastHit2d.collider);
        return CircleRaycastHit2d.collider != null;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor" && ScoreLeftBallPosition())
        {
            score.RightScorePoint();
        }

        if (other.gameObject.tag == "Floor" && ScoreRightBallPosition())
        {
            score.LeftScorePoint();
        }
    }

    private void BallPositionOnStart()
    {
        transform.position = new Vector2(-6, 5);
    }

    private bool ScoreLeftBallPosition()
    {
        bool IsTouchedLeftSide = this.transform.position.x >= -9 && this.transform.position.x <= 0.5;
        return IsTouchedLeftSide;       
    }

    private bool ScoreRightBallPosition()
    {
        bool IsTouchedRightSide = this.transform.position.x >= 0.5 && this.transform.position.x <= 9;
        return IsTouchedRightSide;
    }

}

    


