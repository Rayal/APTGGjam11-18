using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MovementActionController{
    public float targetRadius;
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
}
