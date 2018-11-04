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
<<<<<<< HEAD
    private AudioSource aus;
    private Animator anim;
=======

>>>>>>> 38a11b34d16b88ee39eaae4b15bff738070613b3
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetection>();
<<<<<<< HEAD
        aus = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
=======
>>>>>>> 38a11b34d16b88ee39eaae4b15bff738070613b3
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
<<<<<<< HEAD

=======
>>>>>>> 5d096e5078234236f6a472d63192368df7bded63
        bool jump = Input.GetAxisRaw("Jump") > 0;
        //Around HERE we set the walking/running animation.
        
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        if (jump && gd.IsGrounded())
        {
            //HERE we set the jumping animation.
            //anim.SetBool("Jumping", true);
            rb.AddForce(new Vector2(0, jumpForce));
        }
        else {
            //anim.SetBool("Jumping", false);
        }

        anim.SetBool("Jumping", !gd.IsGrounded());

        /*Animator ainm;
        ainm.SetBool("jumping@, "true);
        ainm.SetFloat("speed", 12)
        */
    }
}
