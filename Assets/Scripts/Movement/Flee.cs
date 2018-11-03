using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MovementActionController{
	// Update is called once per frame
	public override void FixedUpdate () {
        float difference = transform.position.x - pointOfInterest.x ;
        Moving.SetVelocity(rb,
            difference > 0 ? maxSpeed : -maxSpeed);
	}
}
