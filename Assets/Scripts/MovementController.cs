using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    public float acceleration = 10;
    public float dash = 500;
    public float maxSpeed = 10;
    public float jumpForce = 10;

    private Rigidbody2D rb;
    private GroundDetection gd;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetection>();
	}
	
	// FixedUpdate is called regularly, irrespective of framerate.
	void FixedUpdate ()
    {
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.REAL_TIME))
            RealTimeMovement();
        else
            TurnBasedMovement();
    }

    private void RealTimeMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetAxisRaw("Jump") > 0;

        rb.AddForce(new Vector2(horizontal * acceleration, 0));
        if (jump && gd.IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void TurnBasedMovement()
    {
        Debug.Log("Turn based.");
        if (IsMyTurn())
        {
            Debug.Log("My Turn");
            float horizontal = Input.GetAxisRaw("Horizontal");
            Debug.Log(string.Format("{0}", horizontal));
            rb.AddForce(new Vector2(horizontal * dash, 0));

            if (horizontal != 0f)
            {
                GameController.instance.EndTurn();
                Debug.Log("My turn ended.");
            }
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
