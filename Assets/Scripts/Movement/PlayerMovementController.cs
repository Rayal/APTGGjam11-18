﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
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
        transform.rotation = Quaternion.identity;
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.REAL_TIME))
        {
            RealTimeMovement();
        }
    }

    private void RealTimeMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Moving.SetVelocity(rb, horizontal * maxSpeed);
        //Around HERE we set the walking/running animation.
        bool jump = Input.GetAxisRaw("Jump") > 0;
        if (jump && gd.IsGrounded())
        {
            //HERE we set the jumping animation.
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
