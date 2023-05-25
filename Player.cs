using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform ball;

    private Rigidbody2D playerRigidbody2d;
    private CapsuleCollider2D capsuleCollider2D;

    [SerializeField] private LayerMask groundLayerMask;

    [SerializeField] private float jumpVelocity = 30f;
    [SerializeField] private float moveVelocity = 10f;

    [SerializeField] private float enemyMoveOffset = 0.2f;

    [SerializeField] private bool isPlayer;
    [SerializeField] private bool isAi;

    private void Start()
    {
        playerRigidbody2d = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();

        PlayerPositionOnStart();
    }

    private void Update()
    {
        if (isPlayer)
        {
            HandleMovement();
            HandleJump();
        }
        if (isAi)
        {
            EnemyHandleMovementAi();
        }       
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.CapsuleCast(capsuleCollider2D.bounds.center, capsuleCollider2D.bounds.size, CapsuleDirection2D.Vertical, 0f, Vector2.down, .1f, groundLayerMask);
        
        return raycastHit2d.collider != null;
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            playerRigidbody2d.velocity = new Vector2(-moveVelocity, playerRigidbody2d.velocity.y);
        }
        else 
        {
            if (Input.GetKey(KeyCode.D))
            {
                playerRigidbody2d.velocity = new Vector2(moveVelocity, playerRigidbody2d.velocity.y);
            }
            else 
            {
                playerRigidbody2d.velocity = new Vector2(0, playerRigidbody2d.velocity.y);
            }
        }
    }
    private void HandleJump()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            playerRigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }

    private void PlayerPositionOnStart()
    {
        if (gameObject.CompareTag("Player1"))
        {
            transform.position = new Vector2(-6f, 1.25f);
        }
        if (gameObject.CompareTag("Player2"))
        {
            transform.position = new Vector2(6f, 1.25f);
        } 
    }

    private void EnemyHandleMovementAi()
    {
        if (ball.transform.position.x  < this.transform.position.x + enemyMoveOffset && ball.transform.position.x >= 0.1)
        {
            playerRigidbody2d.velocity = new Vector2(-moveVelocity, playerRigidbody2d.velocity.y);   
        }
        
        if (ball.transform.position.x > this.transform.position.x + enemyMoveOffset)
        {
            playerRigidbody2d.velocity = new Vector2(moveVelocity, playerRigidbody2d.velocity.y);
        }
        
        if (ball.transform.position.y > this.transform.position.y && ball.transform.position.x >= 0.1)
        {
            playerRigidbody2d.velocity = Vector2.up * jumpVelocity;
        }

    }
}

 
