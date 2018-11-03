using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public float maxSpeed;
    public float maxAccel;
    public Vector2 velocity;

    private Moving moving;

	// Use this for initialization
	void Start () {
        velocity = Vector2.zero;
	}

	public virtual void FixedUpdate () {
        Vector3 scale = transform.localScale;
        if (velocity.x > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if (velocity.x < 0)
        {
            scale.x = -Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
	}

    public virtual void LateUpdate()
    {
//        velocity.x += steering.linear * Time.deltaTime;
        if(velocity.magnitude > maxSpeed)
        {
            velocity.Normalize();
            velocity = velocity * maxSpeed;
        }
    }
}
