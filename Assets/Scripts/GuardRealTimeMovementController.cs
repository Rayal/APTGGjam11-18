using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRealTimeMovementController : MonoBehaviour {
    public Vector2[] patrollPoints;
    public float waitTime;
    public float patrollSpeed;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Seek seek;
    public int currentPOIIndex;
    public bool waiting = false;

	// Use this for initialization
	void Start () {
        seek = GetComponent<Seek>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        /*Vector2 scale = transform.localScale;
        if (rb.velocity.x < 0)
            scale.x *= -Mathf.Abs(scale.x);
        else if (rb.velocity.x > 0)
            scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
        */
        if(rb.velocity.x > 0f)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x < 0f)
        {
            sr.flipX = false;
        }
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.REAL_TIME))
        {
            if (Mathf.Abs(transform.position.x - patrollPoints[currentPOIIndex].x) < 0.5f && !waiting)
            {
                waiting = true;
                if (++currentPOIIndex >= patrollPoints.Length)
                {
                    currentPOIIndex = 0;
                }
                StartCoroutine(SitAndWait(waitTime));
            }
            else if (!waiting)
            {
                seek.pointOfInterest = patrollPoints[currentPOIIndex];
                seek.maxSpeed = patrollSpeed;
                seek.targetRadius = 0;
            }
        }
	}

    IEnumerator SitAndWait(float seconds)
    {
        Moving.SetVelocity(rb, 0);
        seek.enabled = false;
        yield return new WaitForSeconds(seconds);
        waiting = false;
        seek.enabled = true;
    }
}
