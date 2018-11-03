using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    public float dash = 500;
    public float maxSpeed = 10;
    public float jumpForce = 10;

    private Rigidbody2D rb;
    private GroundDetection gd;
    private bool currentlyMoving = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetection>();
	}
	
	// FixedUpdate is called regularly, irrespective of framerate.
	void FixedUpdate ()
    {
        transform.rotation = Quaternion.identity;
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.REAL_TIME))
        {
            RealTimeMovement();
        }
        else
        {
            if (currentlyMoving)
            {
                EndTurnOnStop();
            }
            TurnBasedMovement();
        }
    }

    private void EndTurnOnStop()
    {
        if (rb.velocity.Equals(Vector2.zero))
        {
            GameController.instance.EndTurn();
            currentlyMoving = false;
        }
    }

    private void RealTimeMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Moving.SetVelocity(rb, horizontal * maxSpeed);
        bool jump = Input.GetAxisRaw("Jump") > 0;
        if (jump && gd.IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void TurnBasedMovement()
    {
        if (IsMyTurn())
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            rb.AddForce(new Vector2(horizontal * dash, 0));

            if (horizontal != 0f)
            {
                currentlyMoving = true;
            }
        }
        if (rb.velocity.magnitude < maxSpeed * 2 / 3 && currentlyMoving)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private bool IsMyTurn()
    {
        if (tag.Equals("Player") && GameController.instance.GetTurn().Equals(GameController.TurnStatus.PLAYER_TURN))
        {
            return true;
        }
        if (tag.Equals("Enemy") && GameController.instance.GetTurn().Equals(GameController.TurnStatus.ENEMY_TURN))
        {
            return true;
        }
        return false;
    }
}
