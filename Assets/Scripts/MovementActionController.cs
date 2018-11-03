using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementActionController : MonoBehaviour {
    public Vector2 pointOfInterest;
    public float maxSpeed;

    protected Rigidbody2D rb;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	public virtual void FixedUpdate () {
        Moving.SetVelocity(rb, 0f);
	}
}
