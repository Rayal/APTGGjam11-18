﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedMovementController : MonoBehaviour {
    public float dash;

    LineRenderer lr;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        lr.startWidth = 0.1f;
        lr.endWidth = 0.1f;
        lr.startColor = Color.white;
        lr.endColor = Color.white;
	}

    private void FixedUpdate()
    {
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED) && GameController.instance.GetTurn().Equals(GameController.TurnStatus.PLAYER_TURN))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseDirection = (mousePosition - transform.position).normalized;

            if (Input.GetAxisRaw("Fire1") != 0f)
            {
                Debug.Log("Dashed");
                Dash(mouseDirection * dash);
                EndTurn();
            }
            else if (Input.GetAxisRaw("Fire2") != 0f)
            {
                Debug.Log("Fired");
                EndTurn();
            }
        }
    }

    // Update is called once per frame
    void LateUpdate () {
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED))
        {
            if (GameController.instance.GetTurn().Equals(GameController.TurnStatus.PLAYER_TURN))
            {
                VisualiseMovementTrajectory();
            }
        }
		
	}

    private void VisualiseMovementTrajectory()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = (mousePosition - transform.position).normalized;


        Vector3 possibleVelocity = mouseDirection * dash;
        Vector3 p = transform.position;
        Vector3 v = possibleVelocity;
        Vector3 g = Physics2D.gravity;

        float dt = 0.1f;

        lr.positionCount = 10;
        Vector3[] positions = new Vector3[11];
        positions[0] = p;
        for (int i = 0; i < 10; i++)
        {
            v = v + g * dt;
            p = p + v * dt;
            positions[i + 1] = p;
        }

        lr.SetPositions(positions);
    }

    private void Dash(Vector2 dashValue)
    {
        Physics2D.autoSimulation = true;
        rb.velocity = dashValue;
    }

    private void EndTurn()
    {
        lr.positionCount = 0;
        GameController.instance.EndTurn();
    }
}
