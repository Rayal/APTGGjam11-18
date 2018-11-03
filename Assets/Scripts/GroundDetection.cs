using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour {
    private int collidedBodies = 0;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Untangible"))
            collidedBodies++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Untangible"))
            collidedBodies--;
    }

    public bool IsGrounded()
    {
        return collidedBodies > 0;
    }
}
