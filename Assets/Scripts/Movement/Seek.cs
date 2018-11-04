using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MovementActionController{
    public float targetRadius;
<<<<<<< HEAD
    public AudioClip seekingSound;

    private AudioSource aus;
=======
    public AudioClip runningClip;

    private AudioSource audioSource;
>>>>>>> 5d096e5078234236f6a472d63192368df7bded63

    public override void Start()
    {
        base.Start();
<<<<<<< HEAD
        aus = GetComponent<AudioSource>();
=======
        audioSource = GetComponent<AudioSource>();
>>>>>>> 5d096e5078234236f6a472d63192368df7bded63
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
