using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MovementActionController{
    public float targetRadius;
    public AudioClip runningClip;

    private AudioSource audioSource;

    public override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public override void FixedUpdate () {
        float difference = pointOfInterest.x - transform.position.x;
        if (Mathf.Abs(difference) > targetRadius)
        {
            audioSource.clip = runningClip;
            audioSource.loop = true;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

            Moving.SetVelocity(rb,
                difference > 0 ? maxSpeed : -maxSpeed);
        }
        else
        {
            if (audioSource.isPlaying) {
                audioSource.Pause();
            }
            //HERE set the walk/run animation (ENEMY)
            Moving.SetVelocity(rb, 0f);
        }
	}
}
