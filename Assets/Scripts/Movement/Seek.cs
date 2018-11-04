using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MovementActionController{
    public float targetRadius;
    public AudioClip seekingSound;

    private AudioSource aus;

    public override void Start()
    {
        base.Start();
        aus = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void FixedUpdate () {
        float difference = pointOfInterest.x - transform.position.x;
        if (Mathf.Abs(difference) > targetRadius)
        {
            Moving.SetVelocity(rb,
                difference > 0 ? maxSpeed : -maxSpeed);
        }
        else
        {
            //HERE set the walk/run animation (ENEMY)
           
            Moving.SetVelocity(rb, 0f);
        }
	}

    private void LateUpdate()
    {
        SetWalkSound();
    }

    private void SetWalkSound()
    {
        if (rb.velocity.magnitude != 0f)
        {
            aus.clip = seekingSound;
            aus.loop = true;
            if (!aus.isPlaying)
            {
                aus.Play();
            }
        }
        else
        {
            Debug.Log("Here!");
            if (aus.isPlaying)
            {
                aus.loop = false;
                aus.Pause();
            }
        }
    }

}
