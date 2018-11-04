using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour {
    public float dash = 500;
    public float maxSpeed = 10;
    public float jumpForce = 10;
    public AudioClip runningClip;

    private Rigidbody2D rb;
    private GroundDetection gd;
    private AudioSource aus;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetection>();
        aus = GetComponent<AudioSource>();
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
        bool jump = Input.GetAxisRaw("Jump") > 0;
        //Around HERE we set the walking/running animation.
        if (jump && gd.IsGrounded())
        {
            //HERE we set the jumping animation.
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
