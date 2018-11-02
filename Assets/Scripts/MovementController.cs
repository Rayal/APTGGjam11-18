using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    public float acceleration = 10;
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
        RealTimeMovement();
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
}
