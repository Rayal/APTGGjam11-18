using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardTurnController : MonoBehaviour {
    public enum GuardIntent
    {
        SHOOT,
        PURSUE
    }

    public GuardIntent intent;
    public GameObject target;
    public float targetRadius;
    public float pursuitSpeed;

    private Seek seek;
    private Pursue pursuitController;

	void Start () {
        pursuitController = GetComponent<Pursue>();
        seek = GetComponent<Seek>();
	}
	
	void FixedUpdate ()
    {
        if (intent.Equals(GuardIntent.PURSUE))
        {
            MovementManagement();
        }
        else if (intent.Equals(GuardIntent.SHOOT))
        {
            FireManagement();
        }
    }

    private void LateUpdate()
    {
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED)
            && GameController.instance.GetTurn().Equals(GameController.TurnStatus.PLAYER_TURN))
        {
            RaycastHit2D hit = ScanForPlayer();
            if (hit.collider.CompareTag("Player"))
            {
                intent = GuardIntent.SHOOT;
            }
            else
            {
                intent = GuardIntent.PURSUE;
            }
        }
    }

    private void FireManagement()
    {
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED)
                    && GameController.instance.GetTurn().Equals(GameController.TurnStatus.ENEMY_TURN))
        {
            RaycastHit2D hit = ScanForPlayer();
            if (hit.collider.CompareTag("Player"))
            {
                GameController.instance.PlayerHit();
            }
        }
    }

    private RaycastHit2D ScanForPlayer()
    {
        Vector2 rayCastDirection = target.transform.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(
           transform.position,
           rayCastDirection,
           Mathf.Infinity,
           ~(LayerMask.GetMask("Enemy") | LayerMask.GetMask("Ignore Raycast")));
        return hit;
    }

    private void MovementManagement()
    {
        if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED)
                    && GameController.instance.GetTurn().Equals(GameController.TurnStatus.ENEMY_TURN))
        {
            seek.enabled = true;
            seek.targetRadius = targetRadius;
            seek.maxSpeed = pursuitSpeed;
            Physics2D.autoSimulation = true;
            if (intent.Equals(GuardIntent.PURSUE))
            {
                pursuitController.enabled = true;
                pursuitController.target = target;
                GameController.instance.EndTurn();
            }
        }
        else if (GameController.instance.GetPlayMode().Equals(GameController.PlayMode.TURN_BASED)
            && (GameController.instance.GetTurn().Equals(GameController.TurnStatus.PLAYER_TURN)
            || GameController.instance.GetTurn().Equals(GameController.TurnStatus.PLAYER_ENEMY_TRANSITION)))
        {
            seek.enabled = false;
            pursuitController.enabled = false;
        }
    }
}
