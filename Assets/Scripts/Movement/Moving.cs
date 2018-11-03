using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving {
    public static void SetVelocity(Rigidbody2D rb, float velocity)
    {
        Vector2 vel = rb.velocity;
        vel.x = velocity;

        rb.velocity = vel;
    }
}
