using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardRealTimeMovementController : MonoBehaviour {
    public Vector2[] patrollPoints;
    public float waitTime;
    public float patrollSpeed;

    private Rigidbody2D rb;
    private Seek seek;
    public int currentPOIIndex;
    public bool waiting = false;

	// Use this for initialization
	void Start () {
        seek = GetComponent<Seek>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 scale = transform.localScale;
        if (rb.velocity.x < 0)
            scale.x = -1;
        else if (rb.velocity.x > 0)
            scale.x = 1;
        transform.localScale = scale;

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
